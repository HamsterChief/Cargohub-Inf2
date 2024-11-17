using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class SupplierService : ISupplierService
{
    private readonly DatabaseContext _context;

    public SupplierService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Supplier> ReadSupplier(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id); 
        if (supplier != null)
        {
            return supplier;
        }
        return null;
    }

    public async Task<bool> CreateSupplier(Supplier supplier)
    {
        supplier.created_at = DateTime.UtcNow;
        supplier.updated_at = DateTime.UtcNow;
        _context.Suppliers.Add(supplier); 
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateSupplier(Supplier supplier, int id)
    {
        var supplier_to_update = await _context.Suppliers.FindAsync(id); 
        if (supplier_to_update == null)
        {
            return false;
        }

        supplier_to_update.code = supplier.code;
        supplier_to_update.name = supplier.name;
        supplier_to_update.address = supplier.address;
        supplier_to_update.address_extra = supplier.address_extra;
        supplier_to_update.city = supplier.city;
        supplier_to_update.zip_code = supplier.zip_code;
        supplier_to_update.province = supplier.province;
        supplier_to_update.country = supplier.country;
        supplier_to_update.contact_name = supplier.contact_name;
        supplier_to_update.phonenumber = supplier.phonenumber;
        supplier_to_update.reference = supplier.reference;
        supplier_to_update.updated_at = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteSupplier(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id); 
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
    public Task<Supplier> ReadSupplier(int id);
    public Task<bool> CreateSupplier(Supplier supplier);
    public Task<bool> UpdateSupplier(Supplier supplier, int id);
    public Task<bool> DeleteSupplier(int id);
}
