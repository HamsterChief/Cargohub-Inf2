import requests

# Documentation: https://docs.python-requests.org

# TODO: replace with test server url
BASE_URL = "http://localhost:3000"

# Clients:
# IT-auth-get-clients


def test_auth_get_clients():
    response = requests.get(f"{BASE_URL}/api/v1/clients")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_clients():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/clients/1", headers=header)
    assert response.status_code == 401


def test_data_post_clients():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}
    client = {
        "id": 1,
        "name": "Raymond Inc",
        "address": "1296 Daniel Road Apt. 349",
        "city": "Pierceview",
        "zip_code": "28301",
        "province": "Colorado",
        "country": "United States",
        "contact_name": "Bryan Clark",
        "contact_phone": "242.732.3483x2573",
        "contact_email": "robertcharles@example.net",
        "created_at": "2010-04-28 02:22:53",
        "updated_at": "2022-02-09 20:22:35"
    }

    response = requests.post(
        f"{BASE_URL}/api/v1/clients", headers=header, json=client)

    assert response.status_code == 201


def test_authorized_acces_clients():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/clients/1", headers=header)
    assert response.status_code == 200


def test_data_delete_client():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/clients/1", headers=header)
    assert response.status_code == 200


# inventories:


def test_auth_get_inventories():
    response = requests.get(f"{BASE_URL}/api/v1/inventories")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_inventories():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/inventories/1", headers=header)
    assert response.status_code == 401


def test_data_post_inventories():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}
    inventory = {
        "id": 1,
        "item_id": "P000001",
        "description": "Face-to-face clear-thinking complexity",
        "item_reference": "sjQ23408K",
        "locations": [3211, 24700, 14123, 19538, 31071, 24701, 11606, 11817],
        "total_on_hand": 262,
        "total_expected": 0,
        "total_ordered": 80,
        "total_allocated": 41,
        "total_available": 141,
        "created_at": "2015-02-19 16:08:24",
        "updated_at": "2015-09-26 06:37:56"
    }
    response = requests.post(
        f"{BASE_URL}/api/v1/inventories", headers=header, json=inventory)

    assert response.status_code == 201


def test_authorized_acces_inventories():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/inventories/1", headers=header)
    assert response.status_code == 200


def test_data_delete_inventories():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/inventories/1", headers=header)
    assert response.status_code == 200


# item_groups
def test_auth_get_item_groups():
    response = requests.get(f"{BASE_URL}/api/v1/item_groups")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_item_groups():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/item_groups/1", headers=header)
    assert response.status_code == 401


def test_data_post_item_groups():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}

    item_group = {
        "id": 1,
        "name": "Furniture",
        "description": "",
        "created_at": "2019-09-22 15:51:07",
        "updated_at": "2022-05-18 13:49:28"
    }

    response = requests.post(
        f"{BASE_URL}/api/v1/item_groups", headers=header, json=item_group)

    assert response.status_code == 201


def test_authorized_acces_item_groups():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/item_groups/1", headers=header)
    assert response.status_code == 200


def test_data_delete_item_groups():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/item_groups/1", headers=header)
    assert response.status_code == 200


# item_lines
def test_auth_get_item_lines():
    response = requests.get(f"{BASE_URL}/api/v1/item_lines")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_item_lines():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/item_lines/1", headers=header)
    assert response.status_code == 401


def test_data_post_item_lines():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}

    item_lines = {
        "id": 0,
        "name": "Tech Gadgets",
        "description": "",
        "created_at": "2022-08-18 07:05:25",
        "updated_at": "2023-05-15 15:44:28"
    }

    response = requests.post(
        f"{BASE_URL}/api/v1/item_lines", headers=header, json=item_lines)

    assert response.status_code == 201


def test_authorized_acces_item_lines():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/item_lines/1", headers=header)
    assert response.status_code == 200


def test_data_delete_item_lines():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/item_lines/1", headers=header)
    assert response.status_code == 200


# item_types
def test_auth_get_item_types():
    response = requests.get(f"{BASE_URL}/api/v1/item_types")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_item_types():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/item_types/1", headers=header)
    assert response.status_code == 401


def test_data_post_item_types():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}

    item_types = {
        "id": 0,
        "name": "Laptop",
        "description": "",
        "created_at": "2001-11-02 23:02:40",
        "updated_at": "2008-07-01 04:09:17"
    }

    response = requests.post(
        f"{BASE_URL}/api/v1/item_types", headers=header, json=item_types)

    assert response.status_code == 201


def test_authorized_acces_item_types():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/item_types/1", headers=header)
    assert response.status_code == 200


def test_data_delete_item_types():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/item_types/1", headers=header)
    assert response.status_code == 200


# items
def test_auth_get_items():
    response = requests.get(f"{BASE_URL}/api/v1/items")
    # 401 is access denied
    assert response.status_code == 401


def test_unauthorized_acces_items():
    header = {"API_KEY": "a3b3c3d3e3"}  # fake API key
    response = requests.get(f"{BASE_URL}/api/v1/items/1", headers=header)
    assert response.status_code == 401


def test_data_post_items():
    # Our API key
    header = {"API_KEY": "a1b2c3d4e5"}

    item = {
        "uid": "P000001",
        "code": "sjQ23408K",
        "description": "Face-to-face clear-thinking complexity",
        "short_description": "must",
        "upc_code": "6523540947122",
        "model_number": "63-OFFTq0T",
        "commodity_code": "oTo304",
        "item_line": 11,
        "item_group": 73,
        "item_type": 14,
        "unit_purchase_quantity": 47,
        "unit_order_quantity": 13,
        "pack_order_quantity": 11,
        "supplier_id": 34,
        "supplier_code": "SUP423",
        "supplier_part_number": "E-86805-uTM",
        "created_at": "2015-02-19 16:08:24",
        "updated_at": "2015-09-26 06:37:56"
    }

    response = requests.post(
        f"{BASE_URL}/api/v1/items", headers=header, json=item)

    assert response.status_code == 201


def test_authorized_acces_items():
    header = {"API_KEY": "a1b2c3d4e5"}  # real API
    response = requests.get(f"{BASE_URL}/api/v1/items/1", headers=header)
    assert response.status_code == 200


def test_data_delete_items():
    header = {"API_KEY": "a1b2c3d4e5"}
    response = requests.delete(
        f"{BASE_URL}/api/v1/items/1", headers=header)
    assert response.status_code == 200


# issues with put request item: _groups, _lines and _types 
