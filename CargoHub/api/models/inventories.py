import json
import sqlite3
from models.base import Base

INVENTORIES = []


class Inventories(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "inventories.json"
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
            f = open(self.data_path, "r")
            self.data = json.load(f)
            f.close()

    def save(self):
        f = open(self.data_path, "w")
        json.dump(self.data, f)
        f.close()

    # def __init__(self, root_path, is_debug=False):
    #     self.data_path = root_path + "cargohub.db"
    #     self.load(is_debug)

    # def get_inventories(self):
    #     return self.data

    # def get_inventory(self, inventory_id):
    #     for x in self.data:
    #         if x["id"] == inventory_id:
    #             return x
    #     return None

    # def get_inventories_for_item(self, item_id):
    #     result = []
    #     for x in self.data:
    #         if x["item_id"] == item_id:
    #             result.append(x)
    #     return result

    # def get_inventory_totals_for_item(self, item_id):
    #     result = {
    #         "total_expected": 0,
    #         "total_ordered": 0,
    #         "total_allocated": 0,
    #         "total_available": 0
    #     }
    #     for x in self.data:
    #         if x["item_id"] == item_id:
    #             result["total_expected"] += x["total_expected"]
    #             result["total_ordered"] += x["total_ordered"]
    #             result["total_allocated"] += x["total_allocated"]
    #             result["total_available"] += x["total_available"]
    #     return result

    # def add_inventory(self, inventory):
    #     inventory["created_at"] = self.get_timestamp()
    #     inventory["updated_at"] = self.get_timestamp()
    #     self.data.append(inventory)

    # def update_inventory(self, inventory_id, inventory):
    #     inventory["updated_at"] = self.get_timestamp()
    #     for i in range(len(self.data)):
    #         if self.data[i]["id"] == inventory_id:
    #             self.data[i] = inventory
    #             break

    # def remove_inventory(self, inventory_id):
    #     for x in self.data:
    #         if x["id"] == inventory_id:
    #             self.data.remove(x)

    # def load(self, is_debug):
    #     if is_debug:
    #         self.data = INVENTORIES
    #     else:
    #         conn = sqlite3.connect(self.data_path)
    #         cursor = conn.cursor()
    #         # select everything from each row from the table
    #         cursor.execute("SELECT * FROM inventories")
    #         self.data = cursor.fetchall()
    #         conn.close()

    # def save(self):
    #     conn = sqlite3.connect(self.data_path)
    #     try:
    #         cursor = conn.cursor()
    #         #executemany to avoid for loop
    #         #first time using might have small issues
    #         #but it is far more efficient
    #         cursor.executemany("""
    #             UPDATE inventories
    #             SET id = ?, item_id = ?, description = ?, item_reference = ?, locations = ?, total_on_hand = ?, total_expected = ?,
    #                            total_ordered = ?, total_allocated = ?, total_available = ?, created_at = ?, updated_at = ?
    #             WHERE id = ?
    #         """, self.data)
    #     except Exception as e:
    #         # Rollback so that data doesn't get corrupted
    #         conn.rollback()
    #         raise e  # Re raise or handle the error
    #     finally:
    #         # Final statement
    #         conn.close()
    #     return