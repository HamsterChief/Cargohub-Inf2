using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ItemService : IItemService
{
    private DatabaseContext _context;

    public ItemService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IItemService
{
    
}
