using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class WarehouseService : IWarehouseService
{
    private readonly DatabaseContext _context;

    public WarehouseService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Warehouse> ReadWarehouse(int warehouse_id)
    {
        var warehouse = await _context.Warehouses.FindAsync(warehouse_id);
        return warehouse!;
    }

    public async Task<List<Warehouse>> ReadWarehouses()
    {
        return await _context.Warehouses.ToListAsync();
    }

    public async Task<List<Location>> ReadLocationsInWarehouse(int warehouse_id)
    {
        return await _context.Locations.Where(location => location.Warehouse_Id == warehouse_id).ToListAsync();
    }

    public async Task<bool> CreateWarehouse(Warehouse warehouse)
    {
        if (_context.Warehouses.Any(x => x.Id == warehouse.Id))
        {
            return false;
        }
        warehouse.Created_At = DateTime.UtcNow;
        warehouse.Updated_At = DateTime.UtcNow;
        _context.Warehouses.Add(warehouse);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateWarehouse(Warehouse warehouse, int warehouse_id)
    {
        var warehouseToUpdate = await _context.Warehouses.FindAsync(warehouse_id);
        if (warehouseToUpdate == null)
        {
            return false;
        }

        warehouseToUpdate.Code = warehouse.Code;
        warehouseToUpdate.Name = warehouse.Name;
        warehouseToUpdate.Address = warehouse.Address;
        warehouseToUpdate.Zip = warehouse.Zip;
        warehouseToUpdate.City = warehouse.City;
        warehouseToUpdate.Province = warehouse.Province;
        warehouseToUpdate.Country = warehouse.Country;
        warehouseToUpdate.Contact = warehouse.Contact;
        warehouseToUpdate.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteWarehouse(int warehouse_id)
    {
        var warehouse = await _context.Warehouses.FindAsync(warehouse_id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface IWarehouseService
{
    public Task<Warehouse> ReadWarehouse(int warehouse_id);

    public Task<List<Warehouse>> ReadWarehouses();
    public Task<List<Location>> ReadLocationsInWarehouse(int warehouse_id);
    public Task<bool> CreateWarehouse(Warehouse warehouse);
    public Task<bool> UpdateWarehouse(Warehouse warehouse, int warehouse_id);
    public Task<bool> DeleteWarehouse(int warehouse_id);
}