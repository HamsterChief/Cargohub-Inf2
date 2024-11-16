import sqlite3
import json

conn = sqlite3.connect('./data/Cargohub.db')
cursor = conn.cursor()

with open('data/suppliers.json', 'r') as file:
    clients = json.load(file)


create_table_query = '''
CREATE TABLE IF NOT EXISTS suppliers (
    id INTEGER PRIMARY KEY,
    code TEXT,
    name TEXT,
    address TEXT,
    address_extra TEXT,
    city TEXT,
    zip_code TEXT,
    province TEXT,
    country TEXT,
    contact_name TEXT,
    phonenumber TEXT,
    reference TEXT,
    created_at TEXT,
    updated_at TEXT
);
'''
cursor.execute(create_table_query)

for supplier in clients:
    cursor.execute("""
        INSERT OR REPLACE INTO suppliers (
            id, code, name, address, address_extra, city, zip_code, province, 
            country, contact_name, phonenumber, reference, created_at, updated_at
        )
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
    """, (
        supplier['id'], supplier['code'], supplier['name'], supplier['address'], 
        supplier['address_extra'], supplier['city'], supplier['zip_code'], 
        supplier['province'], supplier['country'], supplier['contact_name'], 
        supplier['phonenumber'], supplier['reference'], 
        supplier['created_at'], supplier['updated_at']
    ))
conn.commit()
conn.close()
