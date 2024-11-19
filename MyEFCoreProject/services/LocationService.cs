using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LocationService : ILocationService
{
    private DatabaseContext _context;

    public LocationService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Location> ReadLocation(int location_id)
    {
        var location = await _context.Locations.FindAsync(location_id);
        return location!;
    }

    public async Task<List<Location>> ReadLocations()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<bool> CreateLocation(Location location)
    {
        location.Created_At = DateTime.UtcNow;
        location.Updated_At = DateTime.UtcNow;
        _context.Locations.Add(location);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateLocation(Location location, int location_id)
    {
        var existingLocation = await _context.Locations.FindAsync(location_id);
        if (existingLocation == null)
        {
            return false;
        }

        existingLocation.Warehouse_Id = location.Warehouse_Id;
        existingLocation.Code = location.Code;
        existingLocation.Name = location.Name;
        existingLocation.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteLocation(int location_id)
    {
        var location = await _context.Locations.FindAsync(location_id);
        if (location == null)
        {
            return false;
        }
        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface ILocationService
{
    public Task<Location> ReadLocation(int location_id);
    public Task<List<Location>> ReadLocations();
    public Task<bool> CreateLocation(Location location);
    public Task<bool> UpdateLocation(Location location, int location_id);
    public Task<bool> DeleteLocation(int location_id);
}
