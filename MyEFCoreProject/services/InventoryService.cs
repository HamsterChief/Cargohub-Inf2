using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class InventoryService : IInventoryService
{
    private readonly DatabaseContext _context;

    public InventoryService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Inventory> ReadInventory(int inventory_id)
    {
        var inventory = await _context.Inventories.FindAsync(inventory_id);
        return inventory!;
    }

    public async Task<List<Inventory>> ReadInventories()
    {
        return await _context.Inventories.ToListAsync();
    }

    public async Task<bool> CreateInventory(Inventory inventory)
    {
        if (_context.Inventories.Any(x => x.Id == inventory.Id))
        {
            return false;
        }
        inventory.Created_At = DateTime.UtcNow;
        inventory.Updated_At = DateTime.UtcNow;
        _context.Inventories.Add(inventory);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateInventory(Inventory inventory, int inventory_id)
    {
        var existingInventory = await _context.Inventories.FindAsync(inventory_id);
        if (existingInventory == null)
        {
            return false;
        }

        existingInventory.Item_Id = inventory.Item_Id;
        existingInventory.Description = inventory.Description;
        existingInventory.Item_Reference = inventory.Item_Reference;
        existingInventory.Locations = inventory.Locations;
        existingInventory.Total_On_Hand = inventory.Total_On_Hand;
        existingInventory.Total_Expected = inventory.Total_Expected;
        existingInventory.Total_Ordered = inventory.Total_Ordered;
        existingInventory.Total_Allocated = inventory.Total_Allocated;
        existingInventory.Total_Available = inventory.Total_Available;
        existingInventory.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteInventory(int inventory_id)
    {
        var inventory = await _context.Inventories.FindAsync(inventory_id);
        if (inventory == null)
        {
            return false;
        }
        _context.Inventories.Remove(inventory);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IInventoryService
{
    public Task<Inventory> ReadInventory(int inventory_id);
    public Task<List<Inventory>> ReadInventories();
    public Task<bool> CreateInventory(Inventory inventory);
    public Task<bool> UpdateInventory(Inventory inventory, int inventory_id);
    public Task<bool> DeleteInventory(int inventory_id);
}
