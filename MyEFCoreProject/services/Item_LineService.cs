using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_LineService : IItem_LineService
{
    private DatabaseContext _context;

    public Item_LineService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Item_Line> ReadItem_Line(int item_line_id)
    {
        var item_line = await _context.Item_Lines.FindAsync(item_line_id);
        return item_line!;
    }

    public async Task<List<Item_Line>> ReadItem_Lines()
    {
        return await _context.Item_Lines.ToListAsync();
    }

    public async Task<List<Item>> ReadItemsForItem_Line(int item_line_id)
    {
        return await _context.Items.Where(item => item.Item_Line == item_line_id).ToListAsync();
    }

    public async Task<bool> CreateItem_Line(Item_Line item_line)
    {
        if (_context.Item_Lines.Any(x => x.Id == item_line.Id))
        {
            return false;
        }
        item_line.Created_At = DateTime.UtcNow;
        item_line.Updated_At = DateTime.UtcNow;
        _context.Item_Lines.Add(item_line);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateItem_Line(Item_Line item_line, int item_line_id)
    {
        var existingItem_Line = await _context.Item_Lines.FindAsync(item_line_id);
        if (existingItem_Line == null)
        {
            return false;
        }

        existingItem_Line.Name = item_line.Name;
        existingItem_Line.Description = item_line.Description;
        existingItem_Line.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteItem_Line(int item_line_id)
    {
        var item_line = await _context.Item_Lines.FindAsync(item_line_id);
        if (item_line == null)
        {
            return false;
        }
        _context.Item_Lines.Remove(item_line);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IItem_LineService
{
    public Task<Item_Line> ReadItem_Line(int item_line_id);
    public Task<List<Item_Line>> ReadItem_Lines();
    public Task<List<Item>> ReadItemsForItem_Line(int item_line_id);
    public Task<bool> CreateItem_Line(Item_Line item_line);
    public Task<bool> UpdateItem_Line(Item_Line item_line, int item_line_id);
    public Task<bool> DeleteItem_Line(int item_line_id);
}
