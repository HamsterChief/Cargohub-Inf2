using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShipmentService : IShipmentService
{
    private DatabaseContext _context;

    public ShipmentService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
    public async Task<Shipment> ReadShipment(int id){

        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment != null){
            return shipment;
        }
        return null;
    }

    public async Task<IEnumerable<Shipment>> GetAllShipments(int page){
        const int defaultPageSize = 200; 

        return await _context.Shipments
                            .AsNoTracking()
                            .Skip((page - 1) * defaultPageSize) 
                            .Take(defaultPageSize) 
                            .ToListAsync();
    }

    public async Task<bool> CreateShipment(Shipment shipment){
        shipment.created_at = DateTime.UtcNow;
        shipment.updated_at = DateTime.UtcNow;
        _context.Shipments.Add(shipment);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateShipment(Shipment shipment, int id){
        var shipment_to_update = await _context.Shipments.FindAsync(id);
        if (shipment_to_update == null){
            return false;
        }

        shipment_to_update.order_date = shipment.order_date;
        shipment_to_update.request_date = shipment.request_date;
        shipment_to_update.shipment_date = shipment.shipment_date;
        shipment_to_update.shipment_type = shipment.shipment_type;
        shipment_to_update.shipment_status = shipment.shipment_status;
        shipment_to_update.notes = shipment.notes;
        shipment_to_update.carrier_code = shipment.carrier_code;
        shipment_to_update.carrier_description = shipment.carrier_code;
        shipment_to_update.service_code = shipment.service_code;
        shipment_to_update.payment_type = shipment.payment_type;
        shipment_to_update.transfer_mode = shipment.transfer_mode;
        shipment_to_update.total_package_count = shipment.total_package_count;
        shipment_to_update.total_package_weight = shipment.total_package_weight;
        shipment_to_update.items = shipment.items;
        shipment_to_update.updated_at = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteShipment(int id){
        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment != null){
            _context.Remove(shipment);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface IShipmentService
{
    public Task<Shipment> ReadShipment(int id);

    public Task<IEnumerable<Shipment>> GetAllShipments(int page);
    public Task<bool> CreateShipment(Shipment shipment);
    public Task<bool> UpdateShipment(Shipment shipment, int id);
    public Task<bool> DeleteShipment(int id);
}
