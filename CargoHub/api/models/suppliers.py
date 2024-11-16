import json
import sqlite3
from models.base import Base

SUPPLIERS = []


class Suppliers(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_suppliers(self):
        return self.data

    def get_supplier(self, supplier_id):
        for x in self.data:
            if x["id"] == supplier_id:
                return x
        return None

    def add_supplier(self, supplier):
        supplier["created_at"] = self.get_timestamp()
        supplier["updated_at"] = self.get_timestamp()
        self.data.append(supplier)

    def update_supplier(self, supplier_id, supplier):
        supplier["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == supplier_id:
                self.data[i] = supplier
                break

    def remove_supplier(self, supplier_id):
        for x in self.data:
            if x["id"] == supplier_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = SUPPLIERS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM suppliers")
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
            cursor.execute("DELETE FROM suppliers")

            # Insert new data
            for supplier in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO suppliers (
                    id, code, name, address, address_extra, city, zip_code, province, 
                    country, contact_name, phonenumber, reference, created_at, updated_at
                )
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    supplier['id'], supplier['code'], supplier['name'], supplier['address'], 
                    supplier['address_extra'], supplier['city'], supplier['zip_code'], 
                    supplier['province'], supplier['country'], supplier['contact_name'], 
                    supplier['phonenumber'], supplier['reference'], 
                    supplier['created_at'], supplier['updated_at']
                ))
            conn.commit()
        except sqlite3.Error as e:
            print(f"Client Database error: {e}")
        finally:
            conn.close()

