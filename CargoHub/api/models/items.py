import json
import sqlite3
from models.base import Base

ITEMS = []


class Items(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "Cargohub.db"
        self.load(is_debug)

    def get_items(self):
        return self.data

    def get_item(self, item_id):
        for x in self.data:
            if x["uid"] == item_id:
                return x
        return None

    def get_items_for_item_line(self, item_line_id):
        result = []
        for x in self.data:
            if x["item_line"] == item_line_id:
                result.append(x)
        return result

    def get_items_for_item_group(self, item_group_id):
        result = []
        for x in self.data:
            if x["item_group"] == item_group_id:
                result.append(x)
        return result

    def get_items_for_item_type(self, item_type_id):
        result = []
        for x in self.data:
            if x["item_type"] == item_type_id:
                result.append(x)
        return result

    def get_items_for_supplier(self, supplier_id):
        result = []
        for x in self.data:
            if x["supplier_id"] == supplier_id:
                result.append(x)
        return result

    def add_item(self, item):
        item["created_at"] = self.get_timestamp()
        item["updated_at"] = self.get_timestamp()
        self.data.append(item)

    def update_item(self, item_id, item):
        item["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["uid"] == item_id:
                self.data[i] = item
                break

    def remove_item(self, item_id):
        for x in self.data:
            if x["uid"] == item_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = ITEMS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM items")
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
            for item in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO items (uid, code, description, short_description, upc_code, model_number, commodity_code, item_line, item_group, item_type, 
                               unit_purchase_quantity, unit_order_quantity, pack_order_quantity, supplier_id, supplier_code, supplier_part_number, created_at, updated_at)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)""",
                               (
                                   item['uid'], item['code'], item['description'], item['short_description'], item['upc_code'], item['model_number'], 
                                   item['commodity_code'], item['item_line'], item['item_group'], item['item_type'], item['unit_purchase_quantity'],
                                   item['unit_order_quantity'], item['pack_order_quantity'], item['supplier_id'], item['supplier_code'], item['supplier_part_number'],
                                   item['created_at'], item['updated_at'] 
                               ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"item group Database error: {e}")
        finally:
            conn.close()
