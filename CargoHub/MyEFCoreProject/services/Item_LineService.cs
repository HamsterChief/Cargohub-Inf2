using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_LineService : IItem_LineService
{
    private DatabaseContext _context;

    public Item_LineService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IItem_LineService
{
    
}
