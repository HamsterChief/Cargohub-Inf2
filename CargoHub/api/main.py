import socketserver
import http.server
import json
import sqlite3

from providers import auth_provider
from providers import data_provider
from providers import key_provider
from transfer_data import json_to_database

from processors import notification_processor


class ApiRequestHandler(http.server.BaseHTTPRequestHandler):

    def handle_get_version_1(self, path, user):
        if not auth_provider.has_access(user, path, "get"):
            self.send_response(403)
            self.end_headers()
            return
        if path[0] == "warehouses":
            paths = len(path)
            match paths:
                case 1:
                    warehouses = data_provider.fetch_warehouse_pool().get_warehouses()
                    self.handle_get_content(warehouses)
                case 2:
                    warehouse_id = int(path[1])
                    warehouse = data_provider.fetch_warehouse_pool().get_warehouse(warehouse_id)
                    self.handle_get_content(warehouse)
                case 3:
                    if path[2] == "locations":
                        warehouse_id = int(path[1])
                        locations = data_provider.fetch_location_pool().get_locations_in_warehouse(warehouse_id)
                        self.handle_get_content(locations)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "locations":
            paths = len(path)
            match paths:
                case 1:
                    locations = data_provider.fetch_location_pool().get_locations()
                    self.handle_get_content(locations)
                case 2:
                    location_id = int(path[1])
                    location = data_provider.fetch_location_pool().get_location(location_id)
                    self.handle_get_content(location)
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "transfers":
            paths = len(path)
            match paths:
                case 1:
                    transfers = data_provider.fetch_transfer_pool().get_transfers()
                    self.handle_get_content(transfers)
                case 2:
                    transfer_id = int(path[1])
                    transfer = data_provider.fetch_transfer_pool().get_transfer(transfer_id)
                    self.handle_get_content(transfer)
                case 3:
                    if path[2] == "items":
                        transfer_id = int(path[1])
                        items = data_provider.fetch_transfer_pool().get_items_in_transfer(transfer_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "items":
            paths = len(path)
            match paths:
                case 1:
                    items = data_provider.fetch_item_pool().get_items()
                    self.handle_get_content(items)
                case 2:
                    item_id = path[1]
                    item = data_provider.fetch_item_pool().get_item(item_id)
                    self.handle_get_content(item)
                case 3:
                    if path[2] == "inventory":
                        item_id = path[1]
                        inventories = data_provider.fetch_inventory_pool().get_inventories_for_item(item_id)
                        self.handle_get_content(inventories)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case 4:
                    if path[2] == "inventory" and path[3] == "totals":
                        item_id = path[1]
                        totals = data_provider.fetch_inventory_pool().get_inventory_totals_for_item(item_id)
                        self.handle_get_content(totals)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "item_lines":
            paths = len(path)
            print(paths, path)

            match paths:
                case 1:
                    item_lines = data_provider.fetch_item_line_pool().get_item_lines()
                    self.handle_get_content(item_lines)
                case 2:
                    item_line_id = int(path[1])
                    item_line = data_provider.fetch_item_line_pool().get_item_line(item_line_id)
                    self.handle_get_content(item_line)
                case 3:
                    if path[2] == "items":
                        item_line_id = int(path[1])
                        items = data_provider.fetch_item_pool().get_items_for_item_line(item_line_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "item_groups":
            paths = len(path)
            match paths:
                case 1:
                    item_groups = data_provider.fetch_item_group_pool().get_item_groups()
                    self.handle_get_content(item_groups)
                case 2:
                    item_group_id = int(path[1])
                    item_group = data_provider.fetch_item_group_pool().get_item_group(item_group_id)
                    self.handle_get_content(item_group)
                case 3:
                    if path[2] == "items":
                        item_group_id = int(path[1])
                        items = data_provider.fetch_item_pool().get_items_for_item_group(item_group_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "item_types":
            paths = len(path)
            match paths:
                case 1:
                    item_types = data_provider.fetch_item_type_pool().get_item_types()
                    self.handle_get_content(item_types)
                case 2:
                    item_type_id = int(path[1])
                    item_type = data_provider.fetch_item_type_pool().get_item_type(item_type_id)
                    self.handle_get_content(item_type)
                case 3:
                    if path[2] == "items":
                        item_type_id = int(path[1])
                        items = data_provider.fetch_item_pool().get_items_for_item_type(item_type_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "inventories":
            paths = len(path)
            match paths:
                case 1:
                    inventories = data_provider.fetch_inventory_pool().get_inventories()
                    self.handle_get_content(inventories)
                case 2:
                    inventory_id = int(path[1])
                    inventory = data_provider.fetch_inventory_pool().get_inventory(inventory_id)
                    self.handle_get_content(inventory)
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "suppliers":
            paths = len(path)
            match paths:
                case 1:
                    suppliers = data_provider.fetch_supplier_pool().get_suppliers()
                    self.send_response(200)
                    self.send_header("Content-type", "application/json")
                    self.end_headers()
                    self.wfile.write(json.dumps(suppliers).encode("utf-8"))
                case 2:
                    supplier_id = int(path[1])
                    supplier = data_provider.fetch_supplier_pool().get_supplier(supplier_id)
                    self.handle_get_content(supplier)
                case 3:
                    if path[2] == "items":
                        supplier_id = int(path[1])
                        items = data_provider.fetch_item_pool().get_items_for_supplier(supplier_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "orders":
            paths = len(path)
            match paths:
                case 1:
                    orders = data_provider.fetch_order_pool().get_orders()
                    self.handle_get_content(orders)
                case 2:
                    order_id = int(path[1])
                    order = data_provider.fetch_order_pool().get_order(order_id)
                    self.handle_get_content(order)
                case 3:
                    if path[2] == "items":
                        order_id = int(path[1])
                        items = data_provider.fetch_order_pool().get_items_in_order(order_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "clients":
            paths = len(path)
            match paths:
                case 1:
                    clients = data_provider.fetch_client_pool().get_clients()
                    self.handle_get_content(clients)
                case 2:
                    client_id = int(path[1])
                    client = data_provider.fetch_client_pool().get_client(client_id)
                    self.handle_get_content(client)
                case 3:
                    if path[2] == "orders":
                        client_id = int(path[1])
                        orders = data_provider.fetch_order_pool().get_orders_for_client(client_id)
                        self.handle_get_content(orders)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "shipments":
            paths = len(path)
            match paths:
                case 1:
                    shipments = data_provider.fetch_shipment_pool().get_shipments()
                    self.handle_get_content(shipments)
                case 2:
                    shipment_id = int(path[1])
                    shipment = data_provider.fetch_shipment_pool().get_shipment(shipment_id)
                    self.handle_get_content(shipment)
                case 3:
                    if path[2] == "orders":
                        shipment_id = int(path[1])
                        orders = data_provider.fetch_order_pool().get_orders_in_shipment(shipment_id)
                        self.handle_get_content(orders)
                    elif path[2] == "items":
                        shipment_id = int(path[1])
                        items = data_provider.fetch_shipment_pool().get_items_in_shipment(shipment_id)
                        self.handle_get_content(items)
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        else:
            self.send_response(404)
            self.end_headers()

    def do_GET(self):
        api_key = self.headers.get("API_KEY")
        user = auth_provider.get_user(api_key)
        
        if user is None:
            self.send_response(401)
            self.end_headers()
        else:
            try:
                path = self.path.split("/")
                if len(path) > 3 and path[1] == "api" and path[2] == "v1":
                    self.handle_get_version_1(path[3:], user)
                else:
                    self.send_response(404)
                    self.end_headers()
            except Exception as e:
                self.send_response(500)
                self.end_headers()

    def handle_get_content(self, contents):
        self.send_response(200)
        self.send_header("Content-type", "application/json")
        self.end_headers()
        self.wfile.write(json.dumps(contents).encode("utf-8"))

    def handle_post_version_1(self, path, user):
        if not auth_provider.has_access(user, path, "post"):
            self.send_response(403)
            self.end_headers()
            return
        if path[0] == "warehouses":
            new_warehouse = self.handle_data_content()
            data_provider.fetch_warehouse_pool().add_warehouse(new_warehouse)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "locations":
            new_location = self.handle_data_content()
            data_provider.fetch_location_pool().add_location(new_location)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "transfers":
            new_transfer = self.handle_data_content()
            data_provider.fetch_transfer_pool().add_transfer(new_transfer)
            notification_processor.push(f"Scheduled batch transfer {new_transfer['id']}")
            self.send_response(201)
            self.end_headers()
        elif path[0] == "items":
            new_item = self.handle_data_content()
            data_provider.fetch_item_pool().add_item(new_item)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "inventories":
            new_inventory = self.handle_data_content()
            data_provider.fetch_inventory_pool().add_inventory(new_inventory)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "suppliers":
            new_supplier = self.handle_data_content()
            data_provider.fetch_supplier_pool().add_supplier(new_supplier)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "orders":
            new_order = self.handle_data_content()
            data_provider.fetch_order_pool().add_order(new_order)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "clients":
            new_client = self.handle_data_content()
            data_provider.fetch_client_pool().add_client(new_client)
            self.send_response(201)
            self.end_headers()
        elif path[0] == "shipments":
            new_shipment = self.handle_data_content()
            data_provider.fetch_shipment_pool().add_shipment(new_shipment)
            self.send_response(201)
            self.end_headers()
        else:
            self.send_response(404)
            self.end_headers()

    def do_POST(self):
        api_key = self.headers.get("API_KEY")
        user = auth_provider.get_user(api_key)
        if user == None:
            self.send_response(401)
            self.end_headers()
        else:
            try:
                path = self.path.split("/")
                if len(path) > 3 and path[1] == "api" and path[2] == "v1":
                    self.handle_post_version_1(path[3:], user)
            except Exception:
                self.send_response(500)
                self.end_headers()

    def handle_put_version_1(self, path, user):
        if not auth_provider.has_access(user, path, "put"):
            self.send_response(403)
            self.end_headers()
            return
        if path[0] == "warehouses":
            warehouse_id = int(path[1])
            updated_warehouse = self.handle_data_content()
            data_provider.fetch_warehouse_pool().update_warehouse(warehouse_id, updated_warehouse)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "locations":
            location_id = int(path[1])
            updated_location = self.handle_data_content()
            data_provider.fetch_location_pool().update_location(location_id, updated_location)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "transfers":
            paths = len(path)
            match paths:
                case 2:
                    transfer_id = int(path[1])
                    updated_transfer = self.handle_data_content()
                    data_provider.fetch_transfer_pool().update_transfer(transfer_id, updated_transfer)
                    self.send_response(200)
                    self.end_headers()
                case 3:
                    if path[2] == "commit":
                        transfer_id = int(path[1])
                        transfer = data_provider.fetch_transfer_pool().get_transfer(transfer_id)
                        for x in transfer["items"]:
                            inventories = data_provider.fetch_inventory_pool().get_inventories_for_item(x["item_id"])
                            for y in inventories:
                                if y["location_id"] == transfer["transfer_from"]:
                                    y["total_on_hand"] -= x["amount"]
                                    y["total_expected"] = y["total_on_hand"] + y["total_ordered"]
                                    y["total_available"] = y["total_on_hand"] - y["total_allocated"]
                                    data_provider.fetch_inventory_pool().update_inventory(y["id"], y)
                                elif y["location_id"] == transfer["transfer_to"]:
                                    y["total_on_hand"] += x["amount"]
                                    y["total_expected"] = y["total_on_hand"] + y["total_ordered"]
                                    y["total_available"] = y["total_on_hand"] - y["total_allocated"]
                                    data_provider.fetch_inventory_pool().update_inventory(y["id"], y)
                        transfer["transfer_status"] = "Processed"
                        data_provider.fetch_transfer_pool().update_transfer(transfer_id, transfer)
                        notification_processor.push(f"Processed batch transfer with id:{transfer['id']}")
                        self.send_response(200)
                        self.end_headers()
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "items":
            item_id = path[1]
            updated_item = self.handle_data_content()
            data_provider.fetch_item_pool().update_item(item_id, updated_item)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_lines":
            item_line_id = int(path[1])
            updated_item_line = self.handle_data_content()
            data_provider.fetch_item_line_pool().update_item_line(item_line_id, updated_item_line)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_groups":
            item_group_id = int(path[1])
            updated_item_group = self.handle_data_content()
            data_provider.fetch_item_group_pool().update_item_group(item_group_id, updated_item_group)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_types":
            item_type_id = int(path[1])
            updated_item_type = self.handle_data_content()
            data_provider.fetch_item_type_pool().update_item_type(item_type_id, updated_item_type)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "inventories":
            inventory_id = int(path[1])
            updated_inventory = self.handle_data_content()
            data_provider.fetch_inventory_pool().update_inventory(inventory_id, updated_inventory)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "suppliers":
            supplier_id = int(path[1])
            updated_supplier = self.handle_data_content()
            data_provider.fetch_supplier_pool().update_supplier(supplier_id, updated_supplier)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "orders":
            paths = len(path)
            match paths:
                case 2:
                    order_id = int(path[1])
                    updated_order = self.handle_data_content()
                    data_provider.fetch_order_pool().update_order(order_id, updated_order)
                    self.send_response(200)
                    self.end_headers()
                case 3:
                    if path[2] == "items":
                        order_id = int(path[1])
                        updated_items = self.handle_data_content()
                        data_provider.fetch_order_pool().update_items_in_order(order_id, updated_items)
                        self.send_response(200)
                        self.end_headers()
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        elif path[0] == "clients":
            client_id = int(path[1])
            updated_client = self.handle_data_content()
            data_provider.fetch_client_pool().update_client(client_id, updated_client)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "shipments":
            paths = len(path)
            match paths:
                case 2:
                    shipment_id = int(path[1])
                    updated_shipment = self.handle_data_content()
                    data_provider.fetch_shipment_pool().update_shipment(shipment_id, updated_shipment)
                    self.send_response(200)
                    self.end_headers()
                case 3:
                    if path[2] == "orders":
                        shipment_id = int(path[1])
                        updated_orders = self.handle_data_content()
                        data_provider.fetch_order_pool().update_orders_in_shipment(shipment_id, updated_orders)
                        self.send_response(200)
                        self.end_headers()
                    elif path[2] == "items":
                        shipment_id = int(path[1])
                        updated_items = self.handle_data_content()
                        data_provider.fetch_shipment_pool().update_items_in_shipment(shipment_id, updated_items)
                        self.send_response(200)
                        self.end_headers()
                    elif path[2] == "commit":
                        pass
                    else:
                        self.send_response(404)
                        self.end_headers()
                case _:
                    self.send_response(404)
                    self.end_headers()
        else:
            self.send_response(404)
            self.end_headers()

    def do_PUT(self):
        api_key = self.headers.get("API_KEY")
        user = auth_provider.get_user(api_key)
        if user == None:
            self.send_response(401)
            self.end_headers()
        else:
            try:
                path = self.path.split("/")
                if len(path) > 3 and path[1] == "api" and path[2] == "v1":
                    self.handle_put_version_1(path[3:], user)
            except Exception:
                self.send_response(500)
                self.end_headers()

    def handle_delete_version_1(self, path, user, model_id):
        if not auth_provider.has_access(user, path, "delete"):
            self.send_response(403)
            self.end_headers()
            return
        if path[0] == "warehouses":
            data_provider.fetch_warehouse_pool().remove_warehouse(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "locations":
            data_provider.fetch_location_pool().remove_location(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "transfers":
            data_provider.fetch_transfer_pool().remove_transfer(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "items":
            data_provider.fetch_item_pool().remove_item(str(model_id))
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_lines":
            data_provider.fetch_item_line_pool().remove_item_line(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_groups":
            data_provider.fetch_item_group_pool().remove_item_group(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "item_types":
            data_provider.fetch_item_type_pool().remove_item_type(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "inventories":
            data_provider.fetch_inventory_pool().remove_inventory(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "suppliers":
            data_provider.fetch_supplier_pool().remove_supplier(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "orders":
            data_provider.fetch_order_pool().remove_order(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "clients":
            data_provider.fetch_client_pool().remove_client(model_id)
            self.send_response(200)
            self.end_headers()
        elif path[0] == "shipments":
            data_provider.fetch_shipment_pool().remove_shipment(model_id)
            self.send_response(200)
            self.end_headers()
        else:
            self.send_response(404)
            self.end_headers()

    def do_DELETE(self):
        api_key = self.headers.get("API_KEY")
        user = auth_provider.get_user(api_key)
        if user == None:
            self.send_response(401)
            self.end_headers()
        else:
            try:
                path = self.path.split("/")
                if len(path) > 3 and path[1] == "api" and path[2] == "v1":
                    model_id = int(path[4])
                    self.handle_delete_version_1(path[3:], user, model_id)
            except Exception:
                self.send_response(500)
                self.end_headers()

    def handle_data_content(self):
        content_length = int(self.headers["Content-Length"])
        post_data = self.rfile.read(content_length)
        return json.loads(post_data.decode())

class transfer_data():
    def __init__(self):
        self.conn = sqlite3.connect('cargohub_database.sqlite')
        self.cursor = self.conn.cursor()

    def transfer(self):
        datasets = {
            "warehouses": data_provider._warehouses.get_warehouses(),
            "clients": data_provider._clients.get_clients(),
            "inventories": data_provider._inventories.get_inventories(),
            "item_groups": data_provider._item_groups.get_item_groups(),
            "item_lines": data_provider._item_lines.get_item_lines(),
            "item_types": data_provider._item_types.get_item_types(),
            "items": data_provider._items.get_items(),
            "locations": data_provider._locations.get_locations(),
            "orders": data_provider._orders.get_orders(),
            "shipments": data_provider._shipments.get_shipments(),
            "suppliers": data_provider._suppliers.get_suppliers(),
            "transfers": data_provider._transfers.get_transfers()
        }

        for table_name, data in datasets.items():
            self.create_table_from_data(table_name, data)
            self.insert_data_into_table(table_name, data)

        self.conn.commit()
        self.conn.close()

    def create_table_from_data(self, table_name, data):
        keys = data[0].keys()
        columns = ", ".join([f"{key} TEXT" for key in keys])
        create_table_query = f"CREATE TABLE IF NOT EXISTS {table_name} ({columns})"
        self.cursor.execute(create_table_query)

    def insert_data_into_table(self, table_name, data):
        keys = data[0].keys()
        columns = ", ".join(keys)
        placeholders = ", ".join(["?" for _ in keys])

        insert_query = f"INSERT INTO {table_name} ({columns}) VALUES ({placeholders})"

        for entry in data:
            values = tuple(str(entry[key]) for key in keys)
            self.cursor.execute(insert_query, values)


if __name__ == "__main__":
    PORT = 3000
    with socketserver.TCPServer(("", PORT), ApiRequestHandler) as httpd:
        auth_provider.init()
        data_provider.init()

        notification_processor.start()
        print(f"Serving on port {PORT}...")
        httpd.serve_forever()