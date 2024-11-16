import json
import sqlite3
from models.base import Base

TRANSFERS = []


class Transfers(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "Cargohub.db"
        self.load(is_debug)

    def get_transfers(self):
        return self.data

    def get_transfer(self, transfer_id):
        for x in self.data:
            if x["id"] == transfer_id:
                return x
        return None

    def get_items_in_transfer(self, transfer_id):
        for x in self.data:
            if x["id"] == transfer_id:
                return x["items"]
        return None

    def add_transfer(self, transfer):
        transfer["transfer_status"] = "Scheduled"
        transfer["created_at"] = self.get_timestamp()
        transfer["updated_at"] = self.get_timestamp()
        self.data.append(transfer)

    def update_transfer(self, transfer_id, transfer):
        transfer["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == transfer_id:
                self.data[i] = transfer
                break

    def remove_transfer(self, transfer_id):
        for x in self.data:
            if x["id"] == transfer_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = TRANSFERS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM transfers")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = []
            for row in cursor.fetchall():
                transfer = dict(zip(columns, row))
                # Convert the items string back into a list of dictionaries
                if 'items' in transfer and transfer['items']:
                    transfer['items'] = json.loads(transfer['items'])
                self.data.append(transfer)
            conn.close()

    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            cursor.execute("DELETE FROM transfers")
            for transfer in self.data:
                # Convert the 'items' list to a JSON string
                items_json = json.dumps(transfer['items'])
                cursor.execute("""
                    INSERT OR REPLACE INTO transfers (
                    id, reference, transfer_from, transfer_to, transfer_status, 
                    created_at, updated_at, items
                )
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    transfer['id'], transfer['reference'], transfer['transfer_from'], 
                    transfer['transfer_to'], transfer['transfer_status'], 
                    transfer['created_at'], transfer['updated_at'], items_json
                ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"Inventory Database error: {e}")
        finally:
            conn.close()