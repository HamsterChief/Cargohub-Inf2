import json
import sqlite3
from models.base import Base

WAREHOUSES = []


class Warehouses(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "Cargohub.db"
        self.load(is_debug)

    def get_warehouses(self):
        return self.data

    def get_warehouse(self, warehouse_id):
        for x in self.data:
            if x["id"] == warehouse_id:
                return x
        return None

    def add_warehouse(self, warehouse):
        warehouse["created_at"] = self.get_timestamp()
        warehouse["updated_at"] = self.get_timestamp()
        self.data.append(warehouse)

    def update_warehouse(self, warehouse_id, warehouse):
        warehouse["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == warehouse_id:
                self.data[i] = warehouse
                break

    def remove_warehouse(self, warehouse_id):
        for x in self.data:
            if x["id"] == warehouse_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = WAREHOUSES
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM warehouses")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = []
            for row in cursor.fetchall():
                warehouse = dict(zip(columns, row))
                # Convert the items string back into a list of dictionaries
                if 'items' in warehouse and warehouse['items']:
                    warehouse['items'] = json.loads(warehouse['items'])
                self.data.append(warehouse)
            conn.close()

    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            cursor.execute("DELETE FROM warehouses")
            for warehouse in self.data:
                # Convert the 'contact' dictionary to a JSON string
                contact_json = json.dumps(warehouse['contact'])
                cursor.execute("""
                    INSERT OR REPLACE INTO warehouses (
                    id, code, name, address, zip, city, province, country, 
                    contact, created_at, updated_at
                )
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                warehouse['id'], warehouse['code'], warehouse['name'], warehouse['address'], warehouse['zip'], 
                warehouse['city'], warehouse['province'], warehouse['country'], 
                contact_json, warehouse['created_at'], warehouse['updated_at']
                ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"Inventory Database error: {e}")
        finally:
            conn.close()



