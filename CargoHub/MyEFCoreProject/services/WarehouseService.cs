using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WarehouseService : IWarehouseService
{
    private DatabaseContext _context;

    public WarehouseService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IWarehouseService
{
    
}
