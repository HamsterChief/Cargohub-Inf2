import sqlite3
import json

conn = sqlite3.connect('./data/Cargohub.db')
cursor = conn.cursor()

with open('data/orders.json', 'r') as file:
    clients = json.load(file)


# Execute the query to delete the table

create_table_query = '''
CREATE TABLE IF NOT EXISTS orders (
    id INTEGER PRIMARY KEY,
    source_id INTEGER,
    order_date TEXT,
    request_date TEXT,
    reference TEXT,
    reference_extra TEXT,
    order_status TEXT,
    notes TEXT,
    shipping_notes TEXT,
    picking_notes TEXT,
    warehouse_id INTEGER,
    ship_to TEXT,
    bill_to TEXT,
    shipment_id INTEGER,
    total_amount REAL,
    total_discount REAL,
    total_tax REAL,
    total_surcharge REAL,
    created_at TEXT,
    updated_at TEXT,
    items TEXT
);
'''
cursor.execute(create_table_query)
for order in clients:
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
                       order['id'], order['source_id'], order['order_date'], order['request_date'], order['reference'], order['reference_extra'],
                       order['order_status'], order['notes'], order['shipping_notes'], order[
                           'picking_notes'], order['warehouse_id'], order['ship_to'],
                       order['bill_to'], order['shipment_id'], order['total_amount'], order[
                           'total_discount'], order['total_tax'], order['total_surcharge'],
                       order['created_at'], order['updated_at'], items_json)
                   )

conn.commit()
conn.close()
