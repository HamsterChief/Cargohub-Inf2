from http import client
import sqlite3
import json

conn = sqlite3.connect('./data/Cargohub.db')
cursor = conn.cursor()

with open('data/inventories.json', 'r') as file:
    clients = json.load(file)

[
  {
    "id": 1,
    "item_id": "P000001",
    "description": "Face-to-face clear-thinking complexity",
    "item_reference": "sjQ23408K",
    "locations": [
      3211,
      24700,
      14123,
      19538,
      31071,
      24701,
      11606,
      11817
    ],
    "total_on_hand": 262,
    "total_expected": 0,
    "total_ordered": 80,
    "total_allocated": 41,
    "total_available": 141,
    "created_at": "2015-02-19 16:08:24",
    "updated_at": "2015-09-26 06:37:56"
  }
]

cursor.execute("DROP TABLE IF EXISTS inventories")

# Create the items table
create_table_query = '''
CREATE TABLE IF NOT EXISTS inventories (
    id INTEGER PRIMARY KEY,
    item_id TEXT,
    description TEXT,
    item_reference TEXT,
    locations TEXT,  -- JSON string to store the list of locations
    total_on_hand INTEGER,
    total_expected INTEGER,
    total_ordered INTEGER,
    total_allocated INTEGER,
    total_available INTEGER,
    created_at TEXT,
    updated_at TEXT
);
'''
cursor.execute(create_table_query)

# Insert or replace data into the items table
for item in clients:
    cursor.execute("""
        INSERT OR REPLACE INTO inventories (
            id, item_id, description, item_reference, locations, total_on_hand,
            total_expected, total_ordered, total_allocated, total_available,
            created_at, updated_at
        )
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        item.get('id'), 
        item.get('item_id'), 
        item.get('description'), 
        item.get('item_reference'), 
        json.dumps(item.get('locations')),  # Convert list to JSON string
        item.get('total_on_hand'), 
        item.get('total_expected'), 
        item.get('total_ordered'), 
        item.get('total_allocated'), 
        item.get('total_available'), 
        item.get('created_at'), 
        item.get('updated_at')
    ))

conn.commit()
conn.close()
