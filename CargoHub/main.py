import sqlite3
import json

conn = sqlite3.connect('Cargohub.db')
cursor = conn.cursor()
with open('data/inventories.json', 'r') as file:
    clients = json.load(file)


# Step 1: Connect to SQLite database
conn = sqlite3.connect('Cargohub.db')
cursor = conn.cursor()
"""
{"id": 1, 
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
"updated_at": "2015-09-26 06:37:56"}"""

cursor.execute('''
CREATE TABLE IF NOT EXISTS inventories (
    id INTEGER PRIMARY KEY,
    item_id INTEGER NOT NULL,
    description TEXT NOT NULL,
    item_reference TEXT,
    locations TEXT,
    total_on_hand INTEGER,
    total_expected INTEGER,
    total_ordered INTEGER,
    total_allocated INTEGER,
    total_available INTEGER,
    created_at TEXT,
    updated_at TEXT
)
''')


for client in clients:
    # Step 2: Insert data into 'items' table
    cursor.execute('''
    INSERT INTO inventories (id, item_id, description, item_reference, locations, total_on_hand, 
                       total_expected, total_ordered, total_allocated, total_available, created_at, updated_at)
                        VALUES (?,?,?,?,?,?,?,?,?,?,?,?)
''', (client['id'], client['item_id'],
      client['description'], client['item_reference'], client['locations'],
      client['total_on_hand'], client['total_expected'], client['total_ordered'],
      client['total_allocated'], client['total_available'], client['created_at'], client['updated_at']))


conn.commit()
conn.close()
