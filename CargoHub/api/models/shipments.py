import json
import sqlite3

from models.base import Base
from providers import data_provider

SHIPMENTS = []


class Shipments(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "Cargohub.db"
        self.load(is_debug)

    def get_shipments(self):
        return self.data

    def get_shipment(self, shipment_id):
        for x in self.data:
            if x["id"] == shipment_id:
                return x
        return None

    def get_items_in_shipment(self, shipment_id):
        for x in self.data:
            if x["id"] == shipment_id:
                return x["items"]
        return None

    def add_shipment(self, shipment):
        shipment["created_at"] = self.get_timestamp()
        shipment["updated_at"] = self.get_timestamp()
        self.data.append(shipment)

    def update_shipment(self, shipment_id, shipment):
        shipment["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == shipment_id:
                self.data[i] = shipment
                break

    def update_items_in_shipment(self, shipment_id, items):
        shipment = self.get_shipment(shipment_id)
        current = shipment["items"]
        for x in current:
            found = False
            for y in items:
                if x["item_id"] == y["item_id"]:
                    found = True
                    break
            if not found:
                inventories = data_provider.fetch_inventory_pool().get_inventories_for_item(x["item_id"])
                max_ordered = -1
                max_inventory
                for z in inventories:
                    if z["total_ordered"] > max_ordered:
                        max_ordered = z["total_ordered"]
                        max_inventory = z
                max_inventory["total_ordered"] -= x["amount"]
                max_inventory["total_expected"] = y["total_on_hand"] + y["total_ordered"]
                data_provider.fetch_inventory_pool().update_inventory(max_inventory["id"], max_inventory)
        for x in current:
            for y in items:
                if x["item_id"] == y["item_id"]:
                    inventories = data_provider.fetch_inventory_pool().get_inventories_for_item(x["item_id"])
                    max_ordered = -1
                    max_inventory
                    for z in inventories:
                        if z["total_ordered"] > max_ordered:
                            max_ordered = z["total_ordered"]
                            max_inventory = z
                    max_inventory["total_ordered"] += y["amount"] - x["amount"]
                    max_inventory["total_expected"] = y["total_on_hand"] + y["total_ordered"]
                    data_provider.fetch_inventory_pool().update_inventory(max_inventory["id"], max_inventory)
        shipment["items"] = items
        self.update_shipment(shipment_id, shipment)

    def remove_shipment(self, shipment_id):
        for x in self.data:
            if x["id"] == shipment_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = SHIPMENTS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM shipments")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = []
            for row in cursor.fetchall():
                shipment = dict(zip(columns, row))
                # Convert the items string back into a list of dictionaries
                if 'items' in shipment and shipment['items']:
                    shipment['items'] = json.loads(shipment['items'])
                self.data.append(shipment)
            conn.close()

    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            cursor.execute("DELETE FROM shipments")
            for shipment in self.data:
                # Convert the 'items' list to a JSON string
                items_json = json.dumps(shipment['items'])
                cursor.execute("""
                    INSERT OR REPLACE INTO shipments (
                    id, order_id, source_id, order_date, request_date, shipment_date,
                    shipment_type, shipment_status, notes, carrier_code, carrier_description,
                    service_code, payment_type, transfer_mode, total_package_count,
                    total_package_weight, created_at, updated_at, items
                )
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    shipment['id'], shipment['order_id'], shipment['source_id'], shipment['order_date'], shipment['request_date'], shipment['shipment_date'],
                    shipment['shipment_type'], shipment['shipment_status'], shipment['notes'], shipment['carrier_code'], shipment['carrier_description'],
                    shipment['service_code'], shipment['payment_type'], shipment['transfer_mode'], shipment['total_package_count'],
                    shipment['total_package_weight'], shipment['created_at'], shipment['updated_at'], items_json
                ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"Inventory Database error: {e}")
        finally:
            conn.close()

