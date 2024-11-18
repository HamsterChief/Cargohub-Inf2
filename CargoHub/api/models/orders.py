import json
import sqlite3
import ast
from models.base import Base
from providers import data_provider

ORDERS = []


class Orders(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "Cargohub.db"
        self.load(is_debug)

    def get_orders(self):
        return self.data

    def get_order(self, order_id):
        for x in self.data:
            if x["id"] == order_id:
                return x
        return None

    def get_items_in_order(self, order_id):
        for x in self.data:
            if x["id"] == order_id:
                return x["items"]
        return None

    def get_orders_in_shipment(self, shipment_id):
        result = []
        for x in self.data:
            if x["shipment_id"] == shipment_id:
                result.append(x["id"])
        return result

    def get_orders_for_client(self, client_id):
        result = []
        for x in self.data:
            if x["ship_to"] == client_id or x["bill_to"] == client_id:
                result.append(x)
        return result

    def add_order(self, order):
        order["created_at"] = self.get_timestamp()
        order["updated_at"] = self.get_timestamp()
        self.data.append(order)

    def update_order(self, order_id, order):
        order["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == order_id:
                self.data[i] = order
                break

    def update_items_in_order(self, order_id, items):
        order = self.get_order(order_id)
        current = order["items"]
        for x in current:
            found = False
            for y in items:
                if x["item_id"] == y["item_id"]:
                    found = True
                    break
            if not found:
                inventories = data_provider.fetch_inventory_pool(
                ).get_inventories_for_item(x["item_id"])
                min_ordered = 1_000_000_000_000_000_000
                min_inventory
                for z in inventories:
                    if z["total_allocated"] > min_ordered:
                        min_ordered = z["total_allocated"]
                        min_inventory = z
                min_inventory["total_allocated"] -= x["amount"]
                min_inventory["total_expected"] = y["total_on_hand"] + \
                    y["total_ordered"]
                data_provider.fetch_inventory_pool().update_inventory(
                    min_inventory["id"], min_inventory)
        for x in current:
            for y in items:
                if x["item_id"] == y["item_id"]:
                    inventories = data_provider.fetch_inventory_pool(
                    ).get_inventories_for_item(x["item_id"])
                    min_ordered = 1_000_000_000_000_000_000
                    min_inventory
                    for z in inventories:
                        if z["total_allocated"] < min_ordered:
                            min_ordered = z["total_allocated"]
                            min_inventory = z
                min_inventory["total_allocated"] += y["amount"] - x["amount"]
                min_inventory["total_expected"] = y["total_on_hand"] + \
                    y["total_ordered"]
                data_provider.fetch_inventory_pool().update_inventory(
                    min_inventory["id"], min_inventory)
        order["items"] = items
        self.update_order(order_id, order)

    def update_orders_in_shipment(self, shipment_id, orders):
        packed_orders = self.get_orders_in_shipment(shipment_id)
        for x in packed_orders:
            if x not in orders:
                order = self.get_order(x)
                order["shipment_id"] = -1
                order["order_status"] = "Scheduled"
                self.update_order(x, order)
        for x in orders:
            order = self.get_order(x)
            order["shipment_id"] = shipment_id
            order["order_status"] = "Packed"
            self.update_order(x, order)

    def remove_order(self, order_id):
        for x in self.data:
            if x["id"] == order_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = ORDERS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM orders")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = []
            for row in cursor.fetchall():
                # convert from a list value to dict (id: 1 instead of index 0: 1)
                # uses the name of the row in the db as key
                order = dict(zip(columns, row))
                # Convert the items string back into a list of dictionaries
                if 'items' in order and order['items']:
                    order['items'] = json.loads(order['items'])
                self.data.append(order)
            conn.close()

    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            cursor.execute("DELETE FROM orders")
            for order in self.data:
                items_json = json.dumps(order['items'])
                cursor.execute("""
                INSERT OR REPLACE INTO orders (
                    id, source_id, order_date, request_date, reference, reference_extra,
                    order_status, notes, shipping_notes, picking_notes, warehouse_id,
                    ship_to, bill_to, shipment_id, total_amount, total_discount,
                    total_tax, total_surcharge, created_at, updated_at, items
                )
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """,
                               (
                                   order['id'], order['source_id'], order['order_date'], order[
                                       'request_date'], order['reference'], order['reference_extra'],
                                   order['order_status'], order['notes'], order['shipping_notes'], order[
                                       'picking_notes'], order['warehouse_id'], order['ship_to'],
                                   order['bill_to'], order['shipment_id'], order['total_amount'], order[
                                       'total_discount'], order['total_tax'], order['total_surcharge'],
                                   order['created_at'], order['updated_at'], items_json)
                               )
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"Inventory Database error: {e}")
        finally:
            conn.close()
