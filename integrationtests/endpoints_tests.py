import requests

# Documentation: https://docs.python-requests.org

# TODO: replace with test server url
BASE_URL = "http://localhost:3000"

def test_auth_get_clients():
    response = requests.get(f"{BASE_URL}/api/v1/clients", headers={"API_KEY": "a1b2c3d4e5"})
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
    requests.delete(f"{BASE_URL}/api/v1/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    requests.delete(f"{BASE_URL}/api/v1/clients/2", headers={"API_KEY": "a1b2c3d4e5"})
    client_1 = {"id": 1, "name": "Raymond Inc", "address": "1296 Daniel Road Apt. 349", "city": "Pierceview", "zip_code": "28301", "province": "Colorado", "country": "United States", "contact_name": "Bryan Clark", "contact_phone": "242.732.3483x2573", "contact_email": "robertcharles@example.net", "created_at": "2010-04-28 02:22:53", "updated_at": "2022-02-09 20:22:35"}
    client_2 = {"id": 2, "name": "Williams Ltd", "address": "2989 Flores Turnpike Suite 012", "city": "Lake Steve", "zip_code": "08092", "province": "Arkansas", "country": "United States", "contact_name": "Megan Hayden", "contact_phone": "8892853366", "contact_email": "qortega@example.net", "created_at": "1973-02-24 07:36:32", "updated_at": "2014-06-20 17:46:19"}
    post_client_1 = requests.post(f"{BASE_URL}/api/v1/clients", json=client_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_client_2 = requests.post(f"{BASE_URL}/api/v1/clients", json=client_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_client_1.status_code == 201
    assert post_client_2.status_code == 201

def test_data_get_client():
    # To-Do: Uitlezen van client.
    response = requests.get(f"{BASE_URL}/api/v1/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200
    assert response.json().get('id') == 1

def test_data_get_clients():
    # To-Do: Uitlezen van clients.
    response = requests.get(f"{BASE_URL}/api/v1/clients", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200
    assert response.json()[0].get('id') == 1
    assert response.json()[1].get('id') == 2

def test_data_get_orders_for_client():
    # To-Do: Uitlezen uit orders van client, vergelijk orders.
    requests.delete(f"{BASE_URL}/api/v1/orders/1", headers={"API_KEY": "a1b2c3d4e5"})

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
        "created_at": "1992-05-11T07:31:48Z",
        "updated_at": "1992-05-13T03:31:48Z",
        "items": [
            { "item_id": "P005692", "amount": 19 },
            { "item_id": "P005510", "amount": 10 },
            { "item_id": "P004989", "amount": 7 },
            { "item_id": "P000834", "amount": 1 },
            { "item_id": "P005076", "amount": 8 },
            { "item_id": "P010121", "amount": 22 }
        ]
    }
    requests.post(f"{BASE_URL}/api/v1/orders", json=order_1, headers={"API_KEY": "a1b2c3d4e5"})

    get_orders_1 = requests.get(f"{BASE_URL}/api/v1/clients/1/orders", headers={"API_KEY": "a1b2c3d4e5"})
    requests.delete(f"{BASE_URL}/api/v1/orders/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert get_orders_1.status_code == 200

def test_data_put_client():
    # To-Do: Update de client met andere data.
    client_1 = {"id": 1, "name": "Raymond Inc", "address": "1296 Daniel Road Apt. 349", "city": "Pierceview", "zip_code": "28301", "province": "Colorado", "country": "United States", "contact_name": "Clark Kent", "contact_phone": "242.732.3483x2573", "contact_email": "robertcharles@example.net", "created_at": "2024-11-05 02:22:53", "updated_at": "2022-02-09 20:22:35"}
    update_client_1 = requests.put(f"{BASE_URL}/api/v1/clients/1", json=client_1, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_client_1.status_code == 200

def test_data_delete_clients():
    # To-Do: Clients verwijderen en json leegmaken.
    delete_client_1 = requests.delete(f"{BASE_URL}/api/v1/clients/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_client_2 = requests.delete(f"{BASE_URL}/api/v1/clients/2", headers={"API_KEY": "a1b2c3d4e5"})
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
    inventory_1 = {"id": 1, "item_id": "P000001", "description": "Face-to-face clear-thinking complexity", "item_reference": "sjQ23408K", "locations": [3211, 24700, 14123, 19538, 31071, 24701, 11606, 11817], "total_on_hand": 262, "total_expected": 0, "total_ordered": 80, "total_allocated": 41, "total_available": 141, "created_at": "2015-02-19 16:08:24", "updated_at": "2015-09-26 06:37:56"}
    inventory_2 = {"id": 2, "item_id": "P000002", "description": "Focused transitional alliance", "item_reference": "nyg48736S", "locations": [19800, 23653, 3068, 3334, 20477, 20524, 17579, 2271, 2293, 22717], "total_on_hand": 194, "total_expected": 0, "total_ordered": 139, "total_allocated": 0, "total_available": 55, "created_at": "2020-05-31 16:00:08", "updated_at": "2020-11-08 12:49:21"}
    post_inventory_1 = requests.post(f"{BASE_URL}/api/v1/inventories", json=inventory_1, headers={"API_KEY": "a1b2c3d4e5"})
    post_inventory_2 = requests.post(f"{BASE_URL}/api/v1/inventories", json=inventory_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert post_inventory_1.status_code == 201
    assert post_inventory_2.status_code == 201

def test_data_get_inventory():
    # To-Do: Uitlezen van inventory.
    response = requests.get(f"{BASE_URL}/api/v1/inventories/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200

def test_data_get_inventories():
    # To-Do: Uitlezen van inventories.
    response = requests.get(f"{BASE_URL}/api/v1/inventories", headers={"API_KEY": "a1b2c3d4e5"})
    assert response.status_code == 200

def test_data_put_inventory():
    # To-Do: Update de inventory met andere data.
    inventory_1 = {"id": 1, "item_id": "P000001", "description": "Washing Materials", "item_reference": "sjQ23408K", "locations": [3211, 24700, 14123, 19538, 31071, 24701, 11606, 11817], "total_on_hand": 262, "total_expected": 0, "total_ordered": 80, "total_allocated": 41, "total_available": 141, "created_at": "2015-02-19 16:08:24", "updated_at": "2015-09-26 06:37:56"}
    update_inventory_1 = requests.put(f"{BASE_URL}/api/v1/inventories/1", json=inventory_1, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_inventory_1.status_code == 200

def test_data_delete_inventories():
    # To-Do: Inventories verwijderen en json leegmaken.
    delete_inventory_1 = requests.delete(f"{BASE_URL}/api/v1/inventories/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_inventory_2 = requests.delete(f"{BASE_URL}/api/v1/inventories/2", headers={"API_KEY": "a1b2c3d4e5"})
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
    return

def test_data_get_item_group():
    # To-Do: Uitlezen van item_group.
    item_group_1 = requests.get(f"{BASE_URL}/api/v1/item_groups/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_group_1.status_code == 200

def test_data_get_item_groups():
    # To-Do: Uitlezen van item_groups.
    item_groups = requests.get(f"{BASE_URL}/api/v1/item_groups", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_groups.status_code == 200

def test_data_get_items_for_item_group():
    # To-Do: Uitlezen van items van item_group.
    items_for_item_group = requests.get(f"{BASE_URL}/api/v1/item_groups/1/items", headers={"API_KEY": "a1b2c3d4e5"})
    assert items_for_item_group.status_code == 200

def test_data_put_item_group():
    # To-Do: Update de item_group met andere data.
    item_group_1 = {"id": 1, "name": "Furniture", "description": "", "created_at": "2019-09-22 15:51:07", "updated_at": "2022-05-18 13:49:28"}
    # item_group_2 = {"id": 2, "name": "Stationery", "description": "", "created_at": "1999-08-14 13:39:27", "updated_at": "2011-06-16 05:00:47"}
    update_item_group_1 = requests.put(f"{BASE_URL}/api/v1/item_groups/1", json=item_group_1, headers={"API_KEY": "a1b2c3d4e5"})
    # update_item_group_2 = requests.put(f"{BASE_URL}/api/v1/item_groups/2", json=item_group_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_item_group_1.status_code == 200
    # assert update_item_group_2.status_code == 200

def test_data_delete_item_groups():
    # To-Do: Item_groups verwijderen en json leegmaken.
    delete_item_group_1 = requests.delete(f"{BASE_URL}/api/v1/item_groups/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_item_group_2 = requests.delete(f"{BASE_URL}/api/v1/item_groups/2", headers={"API_KEY": "a1b2c3d4e5"})
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
    return

def test_data_get_item_line():
    # To-Do: Uitlezen van item_line.
    item_line_1 = requests.get(f"{BASE_URL}/api/v1/item_lines/1", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_line_1.status_code == 200

def test_data_get_item_lines():
    # To-Do: Uitlezen van item_lines.
    item_lines = requests.get(f"{BASE_URL}/api/v1/item_lines", headers={"API_KEY": "a1b2c3d4e5"})
    assert item_lines.status_code == 200

def test_data_get_items_for_item_line():
    # To-Do: Uitlezen van items van item_line.
    items_for_item_line = requests.get(f"{BASE_URL}/api/v1/item_lines/1/items", headers={"API_KEY": "a1b2c3d4e5"})
    assert items_for_item_line.status_code == 200

def test_data_put_item_line():
    # To-Do: Update de item_line met andere data.
    item_line_1 = {"id": 1, "name": "Furniture", "description": "", "created_at": "2019-09-22 15:51:07", "updated_at": "2022-05-18 13:49:28"}
    # item_line_2 = {"id": 2, "name": "Stationery", "description": "", "created_at": "1999-08-14 13:39:27", "updated_at": "2011-06-16 05:00:47"}
    update_item_line_1 = requests.put(f"{BASE_URL}/api/v1/item_lines/1", json=item_line_1, headers={"API_KEY": "a1b2c3d4e5"})
    # update_item_line_2 = requests.put(f"{BASE_URL}/api/v1/item_lines/2", json=item_line_2, headers={"API_KEY": "a1b2c3d4e5"})
    assert update_item_line_1.status_code == 200
    # assert update_item_line_2.status_code == 200

def test_data_delete_item_lines():
    # To-Do: Item_lines verwijderen en json leegmaken.
    delete_item_line_1 = requests.delete(f"{BASE_URL}/api/v1/item_lines/1", headers={"API_KEY": "a1b2c3d4e5"})
    delete_item_line_2 = requests.delete(f"{BASE_URL}/api/v1/item_lines/2", headers={"API_KEY": "a1b2c3d4e5"})
    assert delete_item_line_1.status_code == 200
    assert delete_item_line_2.status_code == 200