using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class InventoryService : IInventoryService
{
    private readonly DatabaseContext _context;

    public InventoryService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IInventoryService
{
    
}
