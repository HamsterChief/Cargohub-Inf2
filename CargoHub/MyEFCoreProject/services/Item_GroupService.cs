using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Item_GroupService : IItem_GroupService
{
    private DatabaseContext _context;

    public Item_GroupService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface IItem_GroupService
{
    
}
