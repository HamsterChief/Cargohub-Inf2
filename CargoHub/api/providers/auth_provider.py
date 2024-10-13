import sqlite3
import bcrypt
import json  

def get_user(api_key):
    conn = sqlite3.connect('cargohub_database.sqlite')
    cursor = conn.cursor()

    cursor.execute("SELECT * FROM api_keys")
    rows = cursor.fetchall()

    for row in rows:
        hashed_key = row[1]
        app = row[2]
        permissions = row[3]

        if bcrypt.checkpw(api_key.encode('utf-8'), hashed_key):
            conn.close()
            return {
                "api_key": hashed_key,
                "app": app,
                "permissions": json.loads(permissions),  
                "endpoint_access": json.loads(permissions)  
            }

    conn.close()
    return None

@staticmethod
def has_access(user, path, method):
    access = user["endpoint_access"]  
    if access.get("full", False):  
        return True
    return access.get(path, {}).get(method, False)  


