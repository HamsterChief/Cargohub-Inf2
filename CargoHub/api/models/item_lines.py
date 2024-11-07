import json
import sqlite3
from models.base import Base

ITEM_LINES = []


class ItemLines(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_item_lines(self):
        return self.data

    def get_item_line(self, item_line_id):
        for x in self.data:
            if x["id"] == item_line_id:
                return x
        return None

    def add_item_line(self, item_line):
        item_line["created_at"] = self.get_timestamp()
        item_line["updated_at"] = self.get_timestamp()
        self.data.append(item_line)

    def update_item_line(self, item_line_id, item_line):
        item_line["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == item_line_id:
                self.data[i] = item_line
                break

    def remove_item_line(self, item_line_id):
        for x in self.data:
            if x["id"] == item_line_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = ITEM_LINES
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM item_lines")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = [dict(zip(columns, row)) for row in cursor.fetchall()]
            conn.close()


    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            cursor.execute("DELETE FROM item_lines")
            # excecute many has issues with dictionaries sadly still have to use for loop
            for item_line in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO item_lines (id, name, description, created_at, updated_at)
                    VALUES (?, ?, ?, ?, ?)""",
                               (
                                   item_line['id'], item_line["name"], item_line["description"], item_line["created_at"], item_line["updated_at"]
                               ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"item line Database error: {e}")
        finally:
            conn.close()