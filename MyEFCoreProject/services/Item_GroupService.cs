using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_GroupService : IItem_GroupService
{
    private DatabaseContext _context;

    public Item_GroupService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Item_Group> ReadItem_Group(int item_group_id)
    {
        var item_group = await _context.Item_Groups.FindAsync(item_group_id);
        return item_group!;
    }

    public async Task<List<Item_Group>> ReadItem_Groups()
    {
        return await _context.Item_Groups.ToListAsync();
    }

    public async Task<List<Item>> ReadItemsForItem_Group(int item_group_id)
    {
        return await _context.Items.Where(item => item.Item_Group == item_group_id).ToListAsync();
    }

    public async Task<bool> CreateItem_Group(Item_Group item_group)
    {
        item_group.Created_At = DateTime.UtcNow;
        item_group.Updated_At = DateTime.UtcNow;
        _context.Item_Groups.Add(item_group);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateItem_Group(Item_Group item_group, int item_group_id)
    {
        var existingItem_Group = await _context.Item_Groups.FindAsync(item_group_id);
        if (existingItem_Group == null)
        {
            return false;
        }

        existingItem_Group.Name = item_group.Name;
        existingItem_Group.Description = item_group.Description;
        existingItem_Group.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteItem_Group(int item_group_id)
    {
        var item_group = await _context.Item_Groups.FindAsync(item_group_id);
        if (item_group == null)
        {
            return false;
        }
        _context.Item_Groups.Remove(item_group);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IItem_GroupService
{
    public Task<Item_Group> ReadItem_Group(int item_group_id);
    public Task<List<Item_Group>> ReadItem_Groups();
    public Task<List<Item>> ReadItemsForItem_Group(int item_group_id);
    public Task<bool> CreateItem_Group(Item_Group item_group);
    public Task<bool> UpdateItem_Group(Item_Group item_group, int item_group_id);
    public Task<bool> DeleteItem_Group(int item_group_id);
}
