import json
import sqlite3

from models.base import Base

CLIENTS = []


class Clients(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_clients(self):
        return self.data

    def get_client(self, client_id):
        for x in self.data:
            if x["id"] == client_id:
                return x
        return None

    def add_client(self, client):
        client["created_at"] = self.get_timestamp()
        client["updated_at"] = self.get_timestamp()
        self.data.append(client)

    def update_client(self, client_id, client):
        client["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == client_id:
                self.data[i] = client
                break

    def remove_client(self, client_id):
        for x in self.data:
            if x["id"] == client_id:
                print(f"Removing client: {x}")  # Debugging line
                self.data.remove(x)
                break
        else:
            print(f"Client with id {client_id} not found for removal")

    def load(self, is_debug):
        if is_debug:
            self.data = CLIENTS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM clients")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = [dict(zip(columns, row)) for row in cursor.fetchall()]
            conn.close()


    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            
            # Empty the table before inserting new data
            cursor.execute("DELETE FROM clients")

            # Insert new data
            for client in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO clients (id, name, address, city, zip_code, province, country, contact_name, contact_phone, contact_email, created_at, updated_at)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                    (
                        client['id'], client['name'], client['address'], client['city'], client['zip_code'], client['province'],
                        client['country'], client['contact_name'], client['contact_phone'], client['contact_email'],
                        client['created_at'], client['updated_at']
                    ))
            conn.commit()
        except sqlite3.Error as e:
            print(f"Client Database error: {e}")
        finally:
            conn.close()