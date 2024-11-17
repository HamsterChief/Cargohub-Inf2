using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_TypeService : IItem_TypeService
{
    private DatabaseContext _context;

    public Item_TypeService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IItem_TypeService
{
    
}
