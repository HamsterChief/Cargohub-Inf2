import sqlite3
import json

conn = sqlite3.connect('Cargohub.db')
cursor = conn.cursor()
with open('data/orders.json', 'r') as file:
    clients = json.load(file)


# Step 1: Connect to SQLite database
conn = sqlite3.connect('Cargohub.db')
cursor = conn.cursor()


"""
"id": 1,
"source_id": 33,
"order_date": "2019-04-03T11:33:15Z",
"request_date": "2019-04-07T11:33:15Z",
"reference": "ORD00001",
"reference_extra": "Bedreven arm straffen bureau.",
"order_status": "Delivered",
"notes": "Voedsel vijf vork heel.",
"shipping_notes": "Buurman betalen plaats bewolkt.",
"picking_notes": "Ademen fijn volgorde scherp aardappel op leren.",
"warehouse_id": 18,
"ship_to": null,
"bill_to": null,
"shipment_id": 1,
"total_amount": 9905.13,
"total_discount": 150.77,
"total_tax": 372.72,
"total_surcharge": 77.6,
"created_at": "2019-04-03T11:33:15Z",
"updated_at": "2019-04-05T07:33:15Z",
"items": [
            {
                "item_id": "P007435",
                "amount": 23
            }
        ]
"""

cursor.execute('''
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
    updated_at TEXT
    items TEXT
)
''')


for client in clients:
    # Step 2: Insert data into 'items' table
    joined_items = ' | '.join(client['items'])
    cursor.execute('''source_id,
                   order_date,
    request_date,
    reference,
    reference_extra,
    order_status,
    notes,
    shipping_notes,
    picking_notes,
    warehouse_id,
    ship_to,
    bill_to,
    shipment_id,
    total_amount,
    total_discount,
    total_tax,
    total_surcharge,
    created_at,
    updated_at
    items TEXT (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)
''', (client['id'], client['warehouse_id'], client['code'], client['name'], client['created_at'],
      client['updated_at']))


conn.commit()
conn.close()
