using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_TypeService : IItem_TypeService
{
    private DatabaseContext _context;

    public Item_TypeService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Item_Type> ReadItem_Type(int item_type_id)
    {
        var item_type = await _context.Item_Types.FindAsync(item_type_id);
        return item_type!;
    }

    public async Task<List<Item_Type>> ReadItem_Types()
    {
        return await _context.Item_Types.ToListAsync();
    }

    public async Task<List<Item>> ReadItemsForItem_Type(int item_type_id)
    {
        return await _context.Items.Where(item => item.Item_Type == item_type_id).ToListAsync();
    }

    public async Task<bool> CreateItem_Type(Item_Type item_type)
    {
        item_type.Created_At = DateTime.UtcNow;
        item_type.Updated_At = DateTime.UtcNow;
        _context.Item_Types.Add(item_type);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateItem_Type(Item_Type item_type, int item_type_id)
    {
        var existingItem_Type = await _context.Item_Types.FindAsync(item_type_id);
        if (existingItem_Type == null)
        {
            return false;
        }

        existingItem_Type.Name = item_type.Name;
        existingItem_Type.Description = item_type.Description;
        existingItem_Type.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteItem_Type(int item_type_id)
    {
        var item_type = await _context.Item_Types.FindAsync(item_type_id);
        if (item_type == null)
        {
            return false;
        }
        _context.Item_Types.Remove(item_type);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IItem_TypeService
{
    public Task<Item_Type> ReadItem_Type(int item_type_id);
    
    public Task<List<Item_Type>> ReadItem_Types();
    public Task<List<Item>> ReadItemsForItem_Type(int item_type_id);
    public Task<bool> CreateItem_Type(Item_Type item_type);
    public Task<bool> UpdateItem_Type(Item_Type item_type, int item_type_id);
    public Task<bool> DeleteItem_Type(int item_type_id);
}
