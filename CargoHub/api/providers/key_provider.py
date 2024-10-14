import sqlite3
import bcrypt

class key_provider():

    def hash_api_key(api_key):
        salt = bcrypt.gensalt()
        hashed = bcrypt.hashpw(api_key.encode('utf-8'), salt)
        return hashed

    def create_table_if_not_exists():
        conn = sqlite3.connect('cargohub_database.sqlite')
        cursor = conn.cursor()

        cursor.execute('''  
            CREATE TABLE IF NOT EXISTS api_keys (
                id INTEGER PRIMARY KEY,
                api_key TEXT NOT NULL,
                app TEXT NOT NULL,
                permissions TEXT NOT NULL
            )
        ''')
        
        conn.commit()
        conn.close()

    def store_api_key(app, api_key, permissions):
            hashed_key = key_provider.hash_api_key(api_key)
            
            conn = sqlite3.connect('cargohub_database.sqlite')
            cursor = conn.cursor()
            
            cursor.execute("""
                INSERT INTO api_keys (api_key, app, permissions) 
                VALUES (?, ?, ?)
            """, (hashed_key, app, permissions))
            
            conn.commit()
            conn.close()

    def remove_api_key(api_key):
        conn = sqlite3.connect('cargohub_database.sqlite')
        cursor = conn.cursor()

        cursor.execute("SELECT id, api_key FROM api_keys")
        rows = cursor.fetchall()

        for row in rows:
            key_id = row[0]
            hashed_key = row[1]

            if bcrypt.checkpw(api_key.encode('utf-8'), hashed_key):
                cursor.execute("DELETE FROM api_keys WHERE id = ?", (key_id,))
                conn.commit()
                print(f"API key with id {key_id} has been deleted.")
                break
        else:
            print("No matching API key found.")

        conn.close()
