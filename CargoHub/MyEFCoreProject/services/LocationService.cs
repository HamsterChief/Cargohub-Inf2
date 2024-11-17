using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LocationService : ILocationService
{
    private DatabaseContext _context;

    public LocationService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface ILocationService
{
    
}
