using System;
using System.Collections.Generic;

public class Api_Key
{
    public int Id { get; set; }
    public string ApiKey { get; set; }
    public string App { get; set; }
    public Dictionary<string, bool> Permissions { get; set; }
}

public class PropertyItem
{
    public string Item_Id { get; set; }
    public int Amount { get; set; }
}

public class Client
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? zip_code { get; set; }
    public string? province { get; set; }
    public string? country { get; set; }
    public string? contact_name { get; set; }
    public string? contact_phone { get; set; }
    public string? contact_email { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

public class Inventory
{
    public int Id { get; set; }
    public string Item_Id { get; set; }
    public string Description { get; set; }
    public string Reference { get; set; }
    public List<int> Locations { get; set; }
    public int Total_On_Hand { get; set; }
    public int Total_Expected { get; set; }
    public int Total_Ordered { get; set; }
    public int Total_Allocated { get; set; }
    public int Total_Available { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Item_Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Item_Line
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Item_Type
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Item
{
    public string UId { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Short_Description { get; set; }
    public string Upc_Code { get; set; }
    public string Model_Number { get; set; }
    public string Commodity_Code { get; set; }
    public int Item_Line { get; set; }
    public int Item_Group { get; set; }
    public int Item_Type { get; set; }
    public int Unit_Purchase_Quantity { get; set; }
    public int Unit_Order_Quantity { get; set; }
    public int Pack_Order_Quantity { get; set; }
    public int Supplier_Id { get; set; }
    public string Supplier_Code { get; set; }
    public string Supplier_Part_Number { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Location
{
    public int Id { get; set; }
    public int Warehouse_Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int Source_Id { get; set; }
    public string Order_Date { get; set; }
    public string Request_Date { get; set; }
    public string Reference { get; set; }
    public string Reference_Extra { get; set; }
    public string Order_Status { get; set; }
    public string Notes { get; set; }
    public string Shipping_Notes { get; set; }
    public string Picking_Notes { get; set; }
    public int Warehouse_Id { get; set; }
    public string Ship_To { get; set; }
    public string Bill_To { get; set; }
    public int Shipment_Id { get; set; }
    public double Total_Amount { get; set; }
    public double Total_Discount { get; set; }
    public double Total_Tax { get; set; }
    public double Total_Surcharge { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public List<PropertyItem> items { get; set; }
}


public class Shipment
{
    public int id { get; set; }
    public int order_id { get; set; }
    public int source_id { get; set; }
    public string? order_date { get; set; }
    public string? request_date { get; set; }
    public string? shipment_date { get; set; }
    public string? shipment_type { get; set; }
    public string? shipment_status { get; set; }
    public string? notes { get; set; }
    public string? carrier_code { get; set; }
    public string? carrier_description { get; set; }
    public string? service_code { get; set; }
    public string? payment_type { get; set; }
    public string? transfer_mode { get; set; }
    public int total_package_count { get; set; }
    public double total_package_weight { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public List<PropertyItem>? items { get; set; }
}

public class Supplier
{
    public int id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string address_extra { get; set; }
    public string city { get; set; }
    public string zip_code { get; set; }
    public string province { get; set; }
    public string country { get; set; }
    public string contact_name { get; set; }
    public string phonenumber { get; set; }
    public string reference { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}


public class Transfer
{
    public int id { get; set; }
    public string? reference { get; set; }
    public string? transfer_from { get; set; }
    public string? transfer_to { get; set; }
    public string? transfer_status { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public List<PropertyItem>? items { get; set; }
}
public class Warehouse
{
    public int id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string zip { get; set; }
    public string city { get; set; }
    public string province { get; set; }
    public string country { get; set; }
    public Dictionary<string, string> contact { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

