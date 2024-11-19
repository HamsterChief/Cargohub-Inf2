using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

public class ItemService : IItemService
{
    private DatabaseContext _context;

    public ItemService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Item> ReadItem(string item_id)
    {
        var item = await _context.Items.FindAsync(item_id);
        return item!;
    }

    public async Task<List<Item>> ReadItems()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<List<Inventory>> ReadInventoriesForItem(string item_id)
    {
        return await _context.Inventories.Where(inventory => inventory.Item_Id == item_id).ToListAsync();
    }

    public async Task<object> ReadInventoryTotalsForItem(string item_id)
    {
        var result = await _context.Inventories.Where(inventory => inventory.Item_Id == item_id)
            .GroupBy(inventory => inventory.Item_Id)
            .Select(group => new
            {
                total_expected = group.Sum(inventory => inventory.Total_Expected),
                total_ordered = group.Sum(inventory => inventory.Total_Ordered),
                total_allocated = group.Sum(inventory => inventory.Total_Allocated),
                total_available = group.Sum(inventory => inventory.Total_Available)
            }).FirstOrDefaultAsync();
        
        return result ?? new { total_expected = 0, total_ordered = 0, total_allocated = 0, total_available = 0 };
    }

    public async Task<bool> CreateItem(Item item)
    {
        item.Created_At = DateTime.UtcNow;
        item.Updated_At = DateTime.UtcNow;
        _context.Items.Add(item);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateItem(Item item, string item_id)
    {
        var existingItem = await _context.Items.FindAsync(item_id);
        if (existingItem == null)
        {
            return false;
        }

        existingItem.Code = item.Code;
        existingItem.Description = item.Description;
        existingItem.Short_Description = item.Short_Description;
        existingItem.Upc_Code = item.Upc_Code;
        existingItem.Model_Number = item.Model_Number;
        existingItem.Commodity_Code = item.Commodity_Code;
        existingItem.Item_Line = item.Item_Line;
        existingItem.Item_Group = item.Item_Group;
        existingItem.Item_Type = item.Item_Type;
        existingItem.Unit_Purchase_Quantity = item.Unit_Purchase_Quantity;
        existingItem.Unit_Order_Quantity = item.Unit_Order_Quantity;
        existingItem.Pack_Order_Quantity = item.Pack_Order_Quantity;
        existingItem.Supplier_Id = item.Supplier_Id;
        existingItem.Supplier_Code = item.Supplier_Code;
        existingItem.Supplier_Part_Number = item.Supplier_Part_Number;
        existingItem.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteItem(string item_id)
    {
        var item = await _context.Items.FindAsync(item_id);
        if (item == null)
        {
            return false;
        }
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IItemService
{
    public Task<Item> ReadItem(string item_id);
    public Task<List<Item>> ReadItems();
    public Task<List<Inventory>> ReadInventoriesForItem(string item_id);
    public Task<object> ReadInventoryTotalsForItem(string item_id);
    public Task<bool> CreateItem(Item item);
    public Task<bool> UpdateItem(Item item, string item_id);
    public Task<bool> DeleteItem(string item_id);
}
