using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class SupplierService : ISupplierService
{
    private readonly DatabaseContext _context;

    public SupplierService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Supplier> ReadSupplier(int supplier_id)
    {
        var supplier = await _context.Suppliers.FindAsync(supplier_id); 
        return supplier!;
    }

    public async Task<List<Supplier>> ReadSuppliers()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<List<Item>> ReadItemsForSupplier(int supplier_id)
    {
        return await _context.Items.Where(item => item.Supplier_Id == supplier_id).ToListAsync();
    }

    public async Task<bool> CreateSupplier(Supplier supplier)
    {
<<<<<<< HEAD
=======
        if (_context.Suppliers.Any(x => x.Id == supplier.Id))
        {
            return false;
        }
>>>>>>> Jimmy
        supplier.Created_At = DateTime.UtcNow;
        supplier.Updated_At = DateTime.UtcNow;
        _context.Suppliers.Add(supplier); 
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateSupplier(Supplier supplier, int supplier_id)
    {
        var supplier_to_update = await _context.Suppliers.FindAsync(supplier_id); 
        if (supplier_to_update == null)
        {
            return false;
        }

        supplier_to_update.Code = supplier.Code;
        supplier_to_update.Name = supplier.Name;
        supplier_to_update.Address = supplier.Address;
        supplier_to_update.Address_Extra = supplier.Address_Extra;
        supplier_to_update.City = supplier.City;
        supplier_to_update.Zip_Code = supplier.Zip_Code;
        supplier_to_update.Province = supplier.Province;
        supplier_to_update.Country = supplier.Country;
        supplier_to_update.Contact_Name = supplier.Contact_Name;
        supplier_to_update.Phonenumber = supplier.Phonenumber;
        supplier_to_update.Reference = supplier.Reference;
        supplier_to_update.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteSupplier(int supplier_id)
    {
        var supplier = await _context.Suppliers.FindAsync(supplier_id); 
        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier); 
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface ISupplierService
{
    public Task<Supplier> ReadSupplier(int supplier_id);
    public Task<List<Supplier>> ReadSuppliers();
    public Task<List<Item>> ReadItemsForSupplier(int supplier_id);
    public Task<bool> CreateSupplier(Supplier supplier);
    public Task<bool> UpdateSupplier(Supplier supplier, int supplier_id);
    public Task<bool> DeleteSupplier(int supplier_id);
}