import json

from models.base import Base

LOCATIONS = []


class Locations(Base):
    def __init__(self, root_path, is_debug=False):
        self.data_path = root_path + "cargohub.db"
        self.load(is_debug)

    def get_locations(self):
        return self.data

    def get_location(self, location_id):
        for x in self.data:
            if x["id"] == location_id:
                return x
        return None

    def get_locations_in_warehouse(self, warehouse_id):
        result = []
        for x in self.data:
            if x["warehouse_id"] == warehouse_id:
                result.append(x)
        return result

    def add_location(self, location):
        location["created_at"] = self.get_timestamp()
        location["updated_at"] = self.get_timestamp()
        self.data.append(location)

    def update_location(self, location_id, location):
        location["updated_at"] = self.get_timestamp()
        for i in range(len(self.data)):
            if self.data[i]["id"] == location_id:
                self.data[i] = location
                break

    def remove_location(self, location_id):
        for x in self.data:
            if x["id"] == location_id:
                self.data.remove(x)

    def load(self, is_debug):
        if is_debug:
            self.data = LOCATIONS
        else:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # harvest all data from the db table
            cursor.execute("SELECT * FROM locations")
            # Get column names from cursor description
            columns = [description[0] for description in cursor.description]
            # Fetch all rows and convert them to dictionaries
            self.data = [dict(zip(columns, row)) for row in cursor.fetchall()]
            conn.close()


    def save(self):
        try:
            conn = sqlite3.connect(self.data_path)
            cursor = conn.cursor()
            # excecute many has issues with dictionaries sadly still have to use for loop
            for inventory in self.data:
                cursor.execute("""
                    INSERT OR REPLACE INTO inventories (id, warehouse_id, code, name, created_at, updated_at)
                    VALUES (?, ?, ?, ?, ?)""",
                               (
                                   inventory["id"], inventory["warehouse_id"], inventory["code"], inventory["name"], inventory["created_at"], inventory["updated_at"]
                               ))
            conn.commit()
        except sqlite3.Error as e:
            # fail safe if theres an issue with the function
            print(f"inventory Database error: {e}")
        finally:
            conn.close()
