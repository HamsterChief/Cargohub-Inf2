import requests

# Documentation: https://docs.python-requests.org

# TODO: replace with test server url
BASE_URL = "http://localhost:5072/cargohub"
API_KEY = "a1b2c3d4e5"

def test_auth_get_clients():
    response = requests.get(f"{BASE_URL}/clients", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200

# TODO: work out individually before discussing in your team

########################################################################################
# Make integrationtests for resources clients, inventories, item_groups and item_lines.#
########################################################################################

########################################################################################
# integrationtests for clients:                                                        #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ GET    get_clients()
    # ✓ GET    get_client(client_id)
    # ✓ GET    get_orders_for_client(client_id)
    # ✓ POST   add_client(new_client)
    # ✓ PUT    update_client(client_id, updated_client)
    # ✓ DELETE remove_client(client_id)

def test_data_post_client():
    # To-Do: Toevoegen van meerdere clients.
    requests.delete(f"{BASE_URL}/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    requests.delete(f"{BASE_URL}/clients/2", headers={"API_KEY": "a1b2c3d4e5"})
    client_1 = {"id": 1, "name": "Raymond Inc", "address": "1296 Daniel Road Apt. 349", "city": "Pierceview", "zip_code": "28301", "province": "Colorado", "country": "United States", "contact_name": "Bryan Clark", "contact_phone": "242.732.3483x2573", "contact_email": "robertcharles@example.net"}
    client_2 = {"id": 2, "name": "Williams Ltd", "address": "2989 Flores Turnpike Suite 012", "city": "Lake Steve", "zip_code": "08092", "province": "Arkansas", "country": "United States", "contact_name": "Megan Hayden", "contact_phone": "8892853366", "contact_email": "qortega@example.net"}
    post_client_1 = requests.post(f"{BASE_URL}/clients", json=client_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_client_2 = requests.post(f"{BASE_URL}/clients", json=client_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_client_1.status_code == 200
    assert post_client_2.status_code == 200

def test_data_get_client():
    # To-Do: Uitlezen van client.
    response = requests.get(f"{BASE_URL}/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200
    assert response.json().get('id') == 1

def test_data_get_clients():
    # To-Do: Uitlezen van clients.
    response = requests.get(f"{BASE_URL}/clients", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200
    assert response.json()[0].get('id') == 1
    assert response.json()[1].get('id') == 2

def test_data_get_orders_for_client():
    # To-Do: Uitlezen uit orders van client, vergelijk orders.
    requests.delete(f"{BASE_URL}/orders/1", headers={"API_KEY": "a1b2c3d4e5"})

    order_1 = {
        "id": 1,
        "source_id": 38,
        "order_date": "1992-05-11T07:31:48Z",
        "request_date": "1992-05-15T07:31:48Z",
        "reference": "ORD04650",
        "reference_extra": "Schaap doorzichtig nooit lunch lamp.",
        "order_status": "Delivered",
        "notes": "Kleur vroeg stil tweede.",
        "shipping_notes": "Middel klimmen nobel na verstoppen tante.",
        "picking_notes": "Weer lui geur voorzichtig zo.",
        "warehouse_id": 37,
        "ship_to": 1,
        "bill_to": 1,
        "shipment_id": 4650,
        "total_amount": 1155.34,
        "total_discount": 345.29,
        "total_tax": 710.01,
        "total_surcharge": 29.26,
        "items": [
            { "item_id": "P005692", "amount": 19 },
            { "item_id": "P005510", "amount": 10 },
            { "item_id": "P004989", "amount": 7 },
            { "item_id": "P000834", "amount": 1 },
            { "item_id": "P005076", "amount": 8 },
            { "item_id": "P010121", "amount": 22 }
        ]
    }
    requests.post(f"{BASE_URL}/orders", json=order_1, headers={"API_KEY": "a1b2c3d4e5"})

    get_orders_1 = requests.get(f"{BASE_URL}/clients/1/orders", headers={"API_KEY": "a1b2c3d4e5"})
    requests.delete(f"{BASE_URL}/orders/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert get_orders_1.status_code == 200

def test_data_put_client():
    # To-Do: Update de client met andere data.
    client_1 = {"id": 1, "name": "Raymond Inc", "address": "1296 Daniel Road Apt. 349", "city": "Pierceview", "zip_code": "28301", "province": "Colorado", "country": "United States", "contact_name": "Clark Kent", "contact_phone": "242.732.3483x2573", "contact_email": "robertcharles@example.net"}
    update_client_1 = requests.put(f"{BASE_URL}/clients/1", json=client_1, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_client_1.status_code == 200

def test_data_delete_clients():
    # To-Do: Clients verwijderen en json leegmaken.
    delete_client_1 = requests.delete(f"{BASE_URL}/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_client_2 = requests.delete(f"{BASE_URL}/clients/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_client_1.status_code == 200
    assert delete_client_2.status_code == 200

########################################################################################
# integrationtests for inventories:                                                    #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ GET    get_inventories()
    # ✓ GET    get_inventory(inventory_id)
    # ✓ POST   add_inventory(new_inventory)
    # ✓ PUT    update_inventory(inventory_id, updated_inventory)
    # ✓ DELETE remove_inventory(inventory_id)

def test_data_post_inventories():
    # To-Do: Toevoegen van inventories.
    inventory_1 = {"id": 1, "item_id": "P000001", "description": "Face-to-face clear-thinking complexity", "item_reference": "sjQ23408K", "locations": [3211, 24700, 14123, 19538, 31071, 24701, 11606, 11817], "total_on_hand": 262, "total_expected": 0, "total_ordered": 80, "total_allocated": 41, "total_available": 141}
    inventory_2 = {"id": 2, "item_id": "P000002", "description": "Focused transitional alliance", "item_reference": "nyg48736S", "locations": [19800, 23653, 3068, 3334, 20477, 20524, 17579, 2271, 2293, 22717], "total_on_hand": 194, "total_expected": 0, "total_ordered": 139, "total_allocated": 0, "total_available": 55}
    post_inventory_1 = requests.post(f"{BASE_URL}/inventories", json=inventory_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_inventory_2 = requests.post(f"{BASE_URL}/inventories", json=inventory_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_inventory_1.status_code == 200
    assert post_inventory_2.status_code == 200

def test_data_get_inventory():
    # To-Do: Uitlezen van inventory.
    response = requests.get(f"{BASE_URL}/inventories/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200

def test_data_get_inventories():
    # To-Do: Uitlezen van inventories.
    response = requests.get(f"{BASE_URL}/inventories", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200

def test_data_put_inventory():
    # To-Do: Update de inventory met andere data.
    inventory_1 = {"id": 1, "item_id": "P000001", "description": "Washing Materials", "item_reference": "sjQ23408K", "locations": [3211, 24700, 14123, 19538, 31071, 24701, 11606, 11817], "total_on_hand": 262, "total_expected": 0, "total_ordered": 80, "total_allocated": 41, "total_available": 141}
    update_inventory_1 = requests.put(f"{BASE_URL}/inventories/1", json=inventory_1, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_inventory_1.status_code == 200

def test_data_delete_inventories():
    # To-Do: Inventories verwijderen en json leegmaken.
    delete_inventory_1 = requests.delete(f"{BASE_URL}/inventories/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_inventory_2 = requests.delete(f"{BASE_URL}/inventories/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_inventory_1.status_code == 200
    assert delete_inventory_2.status_code == 200

########################################################################################
# integrationtests for item_groups:                                                    #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ POST   'Endpoint niet beschikbaar'
    # ✓ GET    get_item_groups()
    # ✓ GET    get_item_group(item_group_id)
    # ✓ GET    get_items_for_item_group(item_group_id)
    # ✓ PUT    update_item_group(item_group_id, updated_item_group)
    # ✓ DELETE remove_item_group(item_group_id)

def test_data_post_item_groups():
    # To-Do: Toevoegen van item_groups.
    item_group_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_group_2 = {"id": 2, "name": "Stationery", "description": ""}
    post_item_group_1 = requests.post(f"{BASE_URL}/item_groups", json=item_group_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_item_group_2 = requests.post(f"{BASE_URL}/item_groups", json=item_group_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_item_group_1.status_code == 200
    assert post_item_group_2.status_code == 200

def test_data_get_item_group():
    # To-Do: Uitlezen van item_group.
    item_group_1 = requests.get(f"{BASE_URL}/item_groups/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_group_1.status_code == 200

def test_data_get_item_groups():
    # To-Do: Uitlezen van item_groups.
    item_groups = requests.get(f"{BASE_URL}/item_groups", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_groups.status_code == 200

def test_data_get_items_for_item_group():
    # To-Do: Uitlezen van items van item_group.
    items_for_item_group = requests.get(f"{BASE_URL}/item_groups/1/items", headers={"API_KEY": "a1b2c3d4e5"})
    assert items_for_item_group.status_code == 200

def test_data_put_item_group():
    # To-Do: Update de item_group met andere data.
    item_group_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_group_2 = {"id": 2, "name": "Stationery", "description": ""}
    update_item_group_1 = requests.put(f"{BASE_URL}/item_groups/1", json=item_group_1, headers={"API_KEY": "a1b2c3d4e5"})
    update_item_group_2 = requests.put(f"{BASE_URL}/item_groups/2", json=item_group_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_item_group_1.status_code == 200
    assert update_item_group_2.status_code == 200

def test_data_delete_item_groups():
    # To-Do: Item_groups verwijderen en json leegmaken.
    delete_item_group_1 = requests.delete(f"{BASE_URL}/item_groups/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_item_group_2 = requests.delete(f"{BASE_URL}/item_groups/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_item_group_1.status_code == 200
    assert delete_item_group_2.status_code == 200

########################################################################################
# integrationtests for item_lines:                                                     #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ POST   'Endpoint niet beschikbaar'
    # ✓ GET    get_item_lines()
    # ✓ GET    get_item_line(item_line_id)
    # ✓ GET    get_items_for_item_line(item_line_id)
    # ✓ PUT    update_item_line(item_line_id, updated_item_line)
    # ✓ DELETE remove_item_line(item_line_id)

def test_data_post_item_lines():
    # To-Do: Toevoegen van item_lines.
    item_line_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_line_2 = {"id": 2, "name": "Stationery", "description": ""}
    post_item_line_1 = requests.post(f"{BASE_URL}/item_lines", json=item_line_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_item_line_2 = requests.post(f"{BASE_URL}/item_lines", json=item_line_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_item_line_1.status_code == 200
    assert post_item_line_2.status_code == 200

def test_data_get_item_line():
    # To-Do: Uitlezen van item_line.
    item_line_1 = requests.get(f"{BASE_URL}/item_lines/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_line_1.status_code == 200

def test_data_get_item_lines():
    # To-Do: Uitlezen van item_lines.
    item_lines = requests.get(f"{BASE_URL}/item_lines", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_lines.status_code == 200

def test_data_get_items_for_item_line():
    # To-Do: Uitlezen van items van item_line.
    items_for_item_line = requests.get(f"{BASE_URL}/item_lines/1/items", headers={"API_KEY": "a1b2c3d4e5"})
    assert items_for_item_line.status_code == 200

def test_data_put_item_line():
    # To-Do: Update de item_line met andere data.
    item_line_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_line_2 = {"id": 2, "name": "Stationery", "description": ""}
    update_item_line_1 = requests.put(f"{BASE_URL}/item_lines/1", json=item_line_1, headers={"API_KEY": "a1b2c3d4e5"})
    update_item_line_2 = requests.put(f"{BASE_URL}/item_lines/2", json=item_line_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_item_line_1.status_code == 200
    assert update_item_line_2.status_code == 200

def test_data_delete_item_lines():
    # To-Do: Item_lines verwijderen en json leegmaken.
    delete_item_line_1 = requests.delete(f"{BASE_URL}/item_lines/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_item_line_2 = requests.delete(f"{BASE_URL}/item_lines/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_item_line_1.status_code == 200
    assert delete_item_line_2.status_code == 200

########################################################################################
# integrationtests for item_types:                                                     #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ POST   'Endpoint niet beschikbaar'
    # ✓ GET    get_item_types()
    # ✓ GET    get_item_type(item_type_id)
    # ✓ GET    get_items_for_item_type(item_type_id)
    # ✓ PUT    update_item_type(item_type_id, updated_item_type)
    # ✓ DELETE remove_item_type(item_type_id)

def test_data_post_item_types():
    # To-Do: Toevoegen van item_types.
    item_type_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_type_2 = {"id": 2, "name": "Stationery", "description": ""}
    post_item_type_1 = requests.post(f"{BASE_URL}/item_types", json=item_type_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_item_type_2 = requests.post(f"{BASE_URL}/item_types", json=item_type_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_item_type_1.status_code == 200
    assert post_item_type_2.status_code == 200

def test_data_get_item_type():
    # To-Do: Uitlezen van item_type.
    item_type_1 = requests.get(f"{BASE_URL}/item_types/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_type_1.status_code == 200

def test_data_get_item_types():
    # To-Do: Uitlezen van item_types.
    item_types = requests.get(f"{BASE_URL}/item_types", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_types.status_code == 200

def test_data_get_items_for_item_type():
    # To-Do: Uitlezen van items van item_type.
    items_for_item_type = requests.get(f"{BASE_URL}/item_types/1/items", headers={"API_KEY": "a1b2c3d4e5"})
    assert items_for_item_type.status_code == 200

def test_data_put_item_type():
    # To-Do: Update de item_type met andere data.
    item_type_1 = {"id": 1, "name": "Furniture", "description": ""}
    item_type_2 = {"id": 2, "name": "Stationery", "description": ""}
    update_item_type_1 = requests.put(f"{BASE_URL}/item_types/1", json=item_type_1, headers={"API_KEY": "a1b2c3d4e5"})
    update_item_type_2 = requests.put(f"{BASE_URL}/item_types/2", json=item_type_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_item_type_1.status_code == 200
    assert update_item_type_2.status_code == 200

def test_data_delete_item_types():
    # To-Do: Item_types verwijderen en json leegmaken.
    delete_item_type_1 = requests.delete(f"{BASE_URL}/item_types/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_item_type_2 = requests.delete(f"{BASE_URL}/item_types/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_item_type_1.status_code == 200
    assert delete_item_type_2.status_code == 200

########################################################################################
# integrationtests for shipments:                                                      #
########################################################################################

    # (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
    # ✓ GET    get_shipment(shipment_id)
    # ✓ GET    get_updated_shipment(shipment_id)
    # ✓ GET    get_deleted_shipment()
    # ✓ POST   add_shipment(new_client)
    # ✓ PUT    update_shipment(shipment_id, updated_shipment)
    # ✓ DELETE remove_shipment(shipment_id)


def test_empty_data_get_shipments():
    response = requests.get(f"{BASE_URL}/shipments", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    data = response.json()
    assert data == [] or data == {}


def test_data_post_shipment():
    new_shipment = {
        "id": 1,
        "order_id": 1,
        "source_id": 52,
        "order_date": "1973-01-28",
        "request_date": "1973-01-30",
        "shipment_date": "1973-02-01",
        "shipment_type": "I",
        "shipment_status": "Pending",
        "notes": "Hoog genot springen afspraak mond bus.",
        "carrier_code": "DHL",
        "carrier_description": "DHL Express",
        "service_code": "NextDay",
        "payment_type": "Automatic",
        "transfer_mode": "Ground",
        "total_package_count": 29,
        "total_package_weight": 463.0,
        "items": [
            {
                "item_id": "P010669",
                "amount": 16
            }
        ]
    }
    reponse = requests.post(f"{BASE_URL}/shipments", json=new_shipment, headers={"API_KEY": API_KEY})
    assert reponse.status_code == 200


def test_data_get_shipment():
    shipment = {
        "id": 1,
        "order_id": 1,
        "source_id": 52,
        "order_date": "1973-01-28",
        "request_date": "1973-01-30",
        "shipment_date": "1973-02-01",
        "shipment_type": "I",
        "shipment_status": "Pending",
        "notes": "Hoog genot springen afspraak mond bus.",
        "carrier_code": "DHL",
        "carrier_description": "DHL Express",
        "service_code": "NextDay",
        "payment_type": "Automatic",
        "transfer_mode": "Ground",
        "total_package_count": 29,
        "total_package_weight": 463.0,
        "items": [
            {
                "item_id": "P010669",
                "amount": 16
            }
        ]
    }

    response = requests.get(f"{BASE_URL}/shipments/{shipment['id']}", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    response_data = response.json()
    assert response_data == shipment
   
  
def test_data_put_shipment():
    updated_shipment = {
        "id": 1,
        "order_id": 1,
        "source_id": 52,
        "order_date": "1973-01-28",
        "request_date": "1973-01-30",
        "shipment_date": "1973-02-01",
        "shipment_type": "I",
        "shipment_status": "Delivered",
        "notes": "Het is geleverd",
        "carrier_code": "DHL",
        "carrier_description": "DHL Express",
        "service_code": "NextDay",
        "payment_type": "Automatic",
        "transfer_mode": "Ground",
        "total_package_count": 29,
        "total_package_weight": 463.0,
        "items": [
            {
                "item_id": "P010669",
                "amount": 20
            }
        ]
    }

    response = requests.put(f"{BASE_URL}/shipments/{updated_shipment['id']}", json=updated_shipment, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_put_shipment():
    expected_shipment = {
        "id": 1,
        "shipment_status": "Delivered",
        "notes": "Het is geleverd",
        "items": [
            {
                "item_id": "P010669",
                "amount": 20
            }
        ]
    }

    response = requests.get(f"{BASE_URL}/shipments/{expected_shipment['id']}", headers={"API_KEY": API_KEY})
    response_json = response.json()

    assert response_json["shipment_status"] == expected_shipment["shipment_status"]
    assert response_json["notes"] == expected_shipment["notes"]
    assert response_json["items"][0]["amount"] == expected_shipment["items"][0]["amount"]


def test_data_delete_shipment():
    response = requests.delete(f"{BASE_URL}/shipments/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_delete_shipment():
    response = requests.get(f"{BASE_URL}/shipments/1", headers={"API_KEY": API_KEY})
    assert response.json() is None 


########################################################################################
# Integration tests for suppliers:                                                      #
########################################################################################

# (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
# ✓ GET    get_supplier(supplier_id)
# ✓ GET    get_updated_supplier(supplier_id)
# ✓ GET    get_deleted_supplier()
# ✓ POST   add_supplier(new_supplier)
# ✓ PUT    update_supplier(supplier_id, updated_supplier)
# ✓ DELETE remove_supplier(supplier_id)


def test_data_post_supplier():
    new_supplier = {
        "id": 1,
        "code": "SUP0001",
        "name": "Lee, Parks and Johnson",
        "address": "5989 Sullivan Drives",
        "address_extra": "Apt. 996",
        "city": "Port Anitaburgh",
        "zip_code": "91688",
        "province": "Illinois",
        "country": "Czech Republic",
        "contact_name": "Toni Barnett",
        "phonenumber": "363.541.7282x36825",
        "reference": "LPaJ-SUP0001"
    }
    response = requests.post(f"{BASE_URL}/suppliers", json=new_supplier, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_get_supplier():
    supplier = {
        "id": 1,
        "code": "SUP0001",
        "name": "Lee, Parks and Johnson",
        "address": "5989 Sullivan Drives",
        "address_extra": "Apt. 996",
        "city": "Port Anitaburgh",
        "zip_code": "91688",
        "province": "Illinois",
        "country": "Czech Republic",
        "contact_name": "Toni Barnett",
        "phonenumber": "363.541.7282x36825",
        "reference": "LPaJ-SUP0001"
    }

    response = requests.get(f"{BASE_URL}/suppliers/{supplier['id']}", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    response_data = response.json()
    assert response_data == supplier


def test_data_put_supplier():
    updated_supplier = {
        "id": 1,
        "code": "SUP0001",
        "name": "Lee, Parks and Johnson - Updated",
        "address": "5989 Sullivan Drives",
        "address_extra": "Apt. 996",
        "city": "Port Anitaburgh",
        "zip_code": "91688",
        "province": "Illinois",
        "country": "Czech Republic",
        "contact_name": "Toni Barnett",
        "phonenumber": "363.541.7282x36825",
        "reference": "LPaJ-SUP0001"
    }

    response = requests.put(f"{BASE_URL}/suppliers/{updated_supplier['id']}", json=updated_supplier, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_put_supplier():
    supplier = {
        "id": 1,
        "name": "Lee, Parks and Johnson - Updated"
    }

    response = requests.get(f"{BASE_URL}/suppliers/{supplier['id']}", headers={"API_KEY": API_KEY})
    response_data = response.json()
    assert response_data["name"] == supplier["name"]


def test_data_delete_supplier():
    response = requests.delete(f"{BASE_URL}/suppliers/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_delete_supplier():
    response = requests.get(f"{BASE_URL}/suppliers/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    data = response.json()

    assert data in (None, {}, []), f"Expected no data, but got {data}"


########################################################################################
# Integration tests for transfers:                                                      #
########################################################################################

# (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
# ✓ GET    get_transfer(transfer_id)
# ✓ GET    get_updated_transfer(transfer_id)
# ✓ GET    get_deleted_transfer()
# ✓ POST   add_transfer(new_transfer)
# ✓ PUT    update_transfer(transfer_id, updated_transfer)
# ✓ DELETE remove_transfer(transfer_id)


def test_data_post_transfer():
    new_transfer = {
        "id": 1,
        "reference": "TR00001",
        "transfer_from": None,
        "transfer_to": 9229,
        "transfer_status": "Scheduled",
        "items": [
            {
                "item_id": "P007435",
                "amount": 23
            }
        ]
    }

    response = requests.post(f"{BASE_URL}/transfers", json=new_transfer, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_get_transfer():
    transfer = {
        "id": 1,
        "reference": "TR00001",
        "transfer_from": None,
        "transfer_to": 9229,
        "transfer_status": "Scheduled",
        "items": [
            {
                "item_id": "P007435",
                "amount": 23
            }
        ]
    }

    response = requests.get(f"{BASE_URL}/transfers/{transfer['id']}", headers={"API_KEY": API_KEY})
    assert response.status_code == 200

    data = response.json()
    assert data == transfer


def test_data_put_transfer():
    transfer = {
        "id": 1,
        "reference": "TR00001",
        "transfer_from": None,
        "transfer_to": 9229,
        "transfer_status": "Not Completed",
        "items": [
            {
                "item_id": "P007435",
                "amount": 20
            }
        ]
    }

    response = requests.put(f"{BASE_URL}/transfers/{transfer['id']}", json=transfer, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_put_transfer():
    transfer = {
        "id": 1,
        "transfer_status": "Not Completed",
        "items": [
            {
                "item_id": "P007435",
                "amount": 20
            }
        ]
    }
    
    response = requests.get(f"{BASE_URL}/transfers/{transfer['id']}", headers={"API_KEY": API_KEY})
    assert response.status_code == 200

    data = response.json()
    assert data["transfer_status"] == transfer["transfer_status"]
    assert data["items"][0]["amount"] == transfer["items"][0]["amount"]


def test_data_delete_transfer():
    response = requests.delete(f"{BASE_URL}/transfers/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_delete_transfer():
    response = requests.get(f"{BASE_URL}/transfers/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    data = response.json()

    assert data in (None, {}, []), f"Expected no data, but got {data}"


########################################################################################
# Integration tests for warehouses:                                                      #
########################################################################################

# (Checklist) Deze test onderhoud van alle endpoints de inputs/outputs:
# ✓ GET    get_warehouse(warehouse_id)
# ✓ GET    get_updated_warehouse(warehouse_id)
# ✓ GET    get_deleted_warehouse()
# ✓ POST   add_warehouse(new_warehouse)
# ✓ PUT    update_warehouse(warehouse_id, updated_warehouse)
# ✓ DELETE remove_warehouse(warehouse_id)


def test_data_post_warehouse():
    new_warehouse = {
        "id": 1,
        "code": "YQZZNL56",
        "name": "Heemskerk cargo hub",
        "address": "Karlijndreef 281",
        "zip": "4002 AS",
        "city": "Heemskerk",
        "province": "Friesland",
        "country": "NL",
        "contact": {
            "name": "Fem Keijzer",
            "phone": "(078) 0013363",
            "email": "blamore@example.net"
        }
    }

    response = requests.post(f"{BASE_URL}/warehouses", json=new_warehouse, headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_get_warehouse():
    warehouse = {
        "id": 1,
        "code": "YQZZNL56",
        "name": "Heemskerk cargo hub",
        "address": "Karlijndreef 281",
        "zip": "4002 AS",
        "city": "Heemskerk",
        "province": "Friesland",
        "country": "NL",
        "contact": {
            "name": "Fem Keijzer",
            "phone": "(078) 0013363",
            "email": "blamore@example.net"
        }
    }

    response = requests.get(f"{BASE_URL}/warehouses/{warehouse['id']}", headers={"API_KEY": API_KEY})
    assert response.status_code == 200

    data = response.json()
    assert data == warehouse


def test_data_put_warehouse():
    updated_warehouse = {
        "id": 1,
        "code": "YQZZNL56",
        "name": "Heemskerk cargo hub",
        "address": "Karlijndreef 281",
        "zip": "4002 AS",
        "city": "Heemskerk",
        "province": "Groningen",
        "country": "NL",
        "contact": {
            "name": "Fem Keijzer",
            "phone": "(078) 0013363",
            "email": "blamore@example.net"
        }
    }

    response = requests.put(f"{BASE_URL}/warehouses/{updated_warehouse['id']}", json=updated_warehouse,  headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_put_warehouse():
    response = requests.get(f"{BASE_URL}/warehouses/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200

    data = response.json()
    assert data["province"] == "Groningen"


def test_data_delete_warehouse():
    response = requests.delete(f"{BASE_URL}/warehouses/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200


def test_data_check_delete_warehouse():
    response = requests.get(f"{BASE_URL}/warehouses/1", headers={"API_KEY": API_KEY})
    assert response.status_code == 200
    data = response.json()

    assert data in (None, {}, []), f"Expected no data, but got {data}"