import json
import sqlite3
from models.base import Base

INVENTORIES = []


class Inventories(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_inventories(self):
        return self.data

    def get_inventory(self, inventory_id):
        for x in self.data:
            if x["id"] == inventory_id:
                return x
        return None

    def get_inventories_for_item(self, item_id):
        result = []
        for x in self.data:
            if x["item_id"] == item_id:
                result.append(x)
        return result

    def get_inventory_totals_for_item(self, item_id):
        result = {
            "total_expected": 0,
            "total_ordered": 0,
            "total_allocated": 0,
            "total_available": 0
        }
        for x in self.data:
            if x["item_id"] == item_id:
                result["total_expected"] += x["total_expected"]
                result["total_ordered"] += x["total_ordered"]
                result["total_allocated"] += x["total_allocated"]
                result["total_available"] += x["total_available"]
        return result

    def add_inventory(self, inventory):
        inventory["created_at"] = self.get_timestamp()
        inventory["updated_at"] = self.get_timestamp()
        self.data.append(inventory)

    def update_inventory(self, inventory_id, inventory):
        inventory["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == inventory_id:
                self.data[i] = inventory
                break

    def remove_inventory(self, inventory_id):
        for x in self.data:
            if x["id"] == inventory_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = INVENTORIES
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM inventories")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = [dict(zip(columns, row)) for row in cursor.fetchall()]
            conn.close()


    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            cursor.execute("DELETE FROM inventories")
            for inventorie in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO inventories (id, item_id, description, item_reference, locations, total_on_hand, total_expected, total_ordered, total_allocated, total_available, created_at, updated_at)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                               (
                                   inventorie['id'], inventorie['item_id'], inventorie['description'], inventorie['item_reference'], inventorie['locations'], inventorie['total_on_hand'],
                                   inventorie['total_expected'], inventorie['total_ordered'], inventorie['total_allocated'], inventorie['total_available'], inventorie['created_at'], inventorie['updated_at']
                               ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"Inventory Database error: {e}")
        finally:
            conn.close()