import json
import sqlite3
from models.base import Base

ITEM_TYPES = []


class ItemTypes(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_item_types(self):
        return self.data

    def get_item_type(self, item_type_id):
        for x in self.data:
            if x["id"] == item_type_id:
                return x
        return None

    def add_item_type(self, item_type):
        item_type["created_at"] = self.get_timestamp()
        item_type["updated_at"] = self.get_timestamp()
        self.data.append(item_type)

    def update_item_type(self, item_type_id, item_type):
        item_type["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == item_type_id:
                self.data[i] = item_type
                break

    def remove_item_type(self, item_type_id):
        for x in self.data:
            if x["id"] == item_type_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = ITEM_TYPES
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # select everything from each row from the table
            cursor.execute("SELECT * FROM item_types")
            self.data = cursor.fetchall()
            conn.close()

    def save(self):
        conn = sqlite3.connect(self.data_path)
        try:
            cursor = conn.cursor()
            #executemany to avoid for loop
            #first time using might have small issues
            #but it is far more efficient
            cursor.executemany("""
                UPDATE item_types
                SET id = ?, name = ?, description = ?, created_at = ?, updated_at = ?
                WHERE id = ?
            """, self.data)
        except Exception as e:
            # Rollback so that data doesn't get corrupted
            conn.rollback()
            raise e  # Re raise or handle the error
        finally:
            # Final statement
            conn.close()
        return