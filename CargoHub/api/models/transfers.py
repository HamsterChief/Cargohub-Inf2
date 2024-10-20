import json
import sqlite3

from models.base import Base

TRANSFERS = []


class Transfers(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
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
            # select everything from each row from the table
            cursor.execute("SELECT * FROM transfers")
            self.data = cursor.fetchall()
            conn.close()

    def save(self):
        conn = sqlite3.connect(self.data_path)
        try:
            cursor = conn.cursor()
            #executemany to avoid for loop
            #first time using might have small issues
            #but it is far more efficient
            cursor.executemany("""
                UPDATE transfers
                SET id = ?, reference = ?, transfer_from = ?, transfer_to = ?, transfer_status = ?,
                               created_at = ?, updated_at = ?, items = ?
                WHERE id = ?
            """, self.data)
        except Exception as e:
            # Rollback so that data doesn't get corrupted
            conn.rollback()
            raise e  # Re raise or handle the error
        finally:
            # Final statement
            conn.close()
        return
