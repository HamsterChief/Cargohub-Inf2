import sqlite3

from providers.data_provider import _warehouses
from providers.data_provider import _clients
from providers.data_provider import _inventories
from providers.data_provider import _item_groups
from providers.data_provider import _item_lines
from providers.data_provider import _item_types
from providers.data_provider import _items
from providers.data_provider import _locations
from providers.data_provider import _orders
from providers.data_provider import _shipments
from providers.data_provider import _suppliers
from providers.data_provider import _transfers

conn = sqlite3.connect('cargohub_database.sqlite')
cursor = conn.cursor()

def transfer():
    datasets = {
        "warehouses": _warehouses,
        "clients": _clients,
        "inventories": _inventories,
        "item_groups": _item_groups,
        "item_lines": _item_lines,
        "item_types": _item_types,
        "items": _items,
        "locations": _locations,
        "orders": _orders,
        "shipments": _shipments,
        "suppliers": _suppliers,
        "transfers": _transfers
    }

    for table_name, data in datasets.keys():
        create_table_from_data(table_name, data)
        insert_data_into_table(table_name, data)
    
    conn.commit()
    conn.close()

def create_table_from_data(table_name, data):
    keys = data[0].keys()
    columns = ", ".join([f"{key} TEXT" for key in keys])
    create_table_query = f"CREATE TABLE IF NOT EXISTS {table_name} ({columns})"
    cursor.execute(create_table_query)

def insert_data_into_table(table_name, data):
    keys = data[0].keys()
    columns = ", ".join(keys)
    placeholders = ", ".join(["?" for _ in keys])

    insert_query = f"INSERT INTO {table_name} ({columns}) VALUES ({placeholders})"

    for entry in data:
        values = tuple(entry[key] for key in keys)
        cursor.execute(insert_query, values)