using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private DatabaseContext _context;

    public OrderService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IOrderService
{
    
}
