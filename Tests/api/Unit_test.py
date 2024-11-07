import unittest
import os
import sqlite3
from datetime import datetime
from models.clients import Clients
CLIENTS = []


# Sample test data
TEST_DB_PATH = "./Test/data/Cargohub.db"
TEST_CLIENTS = [
    {
        "id": 1,
        "name": "Client A",
        "address": "123 Test St",
        "city": "Testville",
        "zip_code": "12345",
        "province": "Test State",
        "country": "Testland",
        "contact_name": "Alice",
        "contact_phone": "123-456-7890",
        "contact_email": "alice@test.com",
        "created_at": str(datetime.now()),
        "updated_at": str(datetime.now()),
    },
    {
        "id": 2,
        "name": "Client B",
        "address": "456 Sample Ave",
        "city": "Sampletown",
        "zip_code": "67890",
        "province": "Sample State",
        "country": "Sampleland",
        "contact_name": "Bob",
        "contact_phone": "098-765-4321",
        "contact_email": "bob@test.com",
        "created_at": str(datetime.now()),
        "updated_at": str(datetime.now()),
    },
]

class TestClientsIntegration(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        # Update the path to the database based on the current file's location
        cls.db_path = os.path.abspath(os.path.join(os.path.dirname(__file__), '../Testdata/Cargohub.db'))
        print(f"Database path: {cls.db_path}")
        
        # Ensure the directory exists
        os.makedirs(os.path.dirname(cls.db_path), exist_ok=True)

        # Now proceed with the database setup
        cls.setup_database(cls.db_path)
        cls.clients = Clients(root_path="./Testdata/", is_debug=False)

    @classmethod
    def tearDownClass(cls):
        if os.path.exists(cls.db_path):
            os.remove(cls.db_path)

    @classmethod
    def setup_database(cls, db_path):
        conn = sqlite3.connect(db_path)
        cursor = conn.cursor()
        cursor.execute("""
            CREATE TABLE IF NOT EXISTS clients (
                id INTEGER PRIMARY KEY,
                name TEXT,
                address TEXT,
                city TEXT,
                zip_code TEXT,
                province TEXT,
                country TEXT,
                contact_name TEXT,
                contact_phone TEXT,
                contact_email TEXT,
                created_at TEXT,
                updated_at TEXT
            )
        """)
        conn.commit()
        print("Database setup complete. Table 'clients' created.")
        conn.close()

    def test_add_client(self):
        # Add a client and verify it's saved in the database
        new_client = TEST_CLIENTS[0]
        self.clients.add_client(new_client)
        self.clients.save()

        # Check if client was saved
        saved_client = self.clients.get_client(new_client["id"])
        self.assertEqual(saved_client["name"], "Client A")
        self.assertEqual(saved_client["city"], "Testville")

    def test_update_client(self):
        # Update a client and verify changes
        updated_client = TEST_CLIENTS[1].copy()
        self.clients.add_client(updated_client)
        self.clients.save()

        # Modify client details
        updated_client["city"] = "Updated City"
        self.clients.update_client(updated_client["id"], updated_client)
        self.clients.save()

        # Reload client from the database
        reloaded_client = self.clients.get_client(updated_client["id"])
        self.assertEqual(reloaded_client["city"], "Updated City")

    def test_get_client(self):
        # Add multiple clients and verify retrieval by ID
        self.clients.add_client(TEST_CLIENTS[0])
        self.clients.add_client(TEST_CLIENTS[1])
        self.clients.save()

        client_a = self.clients.get_client(1)
        client_b = self.clients.get_client(2)
        
        self.assertEqual(client_a["name"], "Client A")
        self.assertEqual(client_b["name"], "Client B")

    def test_remove_client(self):
        # Add a client, then remove it, and verify it's gone
        client_to_remove = TEST_CLIENTS[1]
        self.clients.add_client(client_to_remove)
        self.clients.save()

        # Remove client
        self.clients.remove_client(client_to_remove["id"])
        self.clients.save()

        # Verify the client was removed
        removed_client = self.clients.get_client(client_to_remove["id"])
        self.assertIsNone(removed_client)

if __name__ == "__main__":
    unittest.main()