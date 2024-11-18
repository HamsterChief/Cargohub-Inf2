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

    public async Task<Warehouse> ReadWarehouse(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse != null)
        {
            return warehouse;
        }
        return null;
    }

    public async Task<IEnumerable<Warehouse>> GetAllWarehouses()
    {
        return await _context.Warehouses.ToListAsync();
    }

    public async Task<bool> CreateWarehouse(Warehouse warehouse)
    {
        warehouse.created_at = DateTime.UtcNow;
        warehouse.updated_at = DateTime.UtcNow;
        _context.Warehouses.Add(warehouse);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateWarehouse(Warehouse warehouse, int id)
    {
        var warehouseToUpdate = await _context.Warehouses.FindAsync(id);
        if (warehouseToUpdate == null)
        {
            return false;
        }

        warehouseToUpdate.code = warehouse.code;
        warehouseToUpdate.name = warehouse.name;
        warehouseToUpdate.address = warehouse.address;
        warehouseToUpdate.zip = warehouse.zip;
        warehouseToUpdate.city = warehouse.city;
        warehouseToUpdate.province = warehouse.province;
        warehouseToUpdate.country = warehouse.country;
        warehouseToUpdate.contact = warehouse.contact;
        warehouseToUpdate.updated_at = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteWarehouse(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
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
    public Task<Warehouse> ReadWarehouse(int id);

    public Task<IEnumerable<Warehouse>> GetAllWarehouses();
    public Task<bool> CreateWarehouse(Warehouse warehouse);
    public Task<bool> UpdateWarehouse(Warehouse warehouse, int id);
    public Task<bool> DeleteWarehouse(int id);
}
