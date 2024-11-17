using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SupplierService : ISupplierService
{
    private DatabaseContext _context;

    public SupplierService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface ISupplierService
{
    
}
