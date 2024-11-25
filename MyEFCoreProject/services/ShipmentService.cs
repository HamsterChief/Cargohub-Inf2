using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShipmentService : IShipmentService
{
    private readonly DatabaseContext _context;

    public ShipmentService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
    public async Task<Shipment> ReadShipment(int shipment_id)
    {
        var shipment = await _context.Shipments.FindAsync(shipment_id);
        return shipment!;
    }

    public async Task<IEnumerable<Shipment>> GetAllShipments(int page){
        const int defaultPageSize = 200; 

        return await _context.Shipments
                            .AsNoTracking()
                            .Skip((page - 1) * defaultPageSize) 
                            .Take(defaultPageSize) 
                            .ToListAsync();
    }

    public async Task<bool> CreateShipment(Shipment shipment)
    {
        if (_context.Shipments.Any(x => x.Id == shipment.Id))
        {
            return false;
        }
        shipment.Created_At = DateTime.UtcNow;
        shipment.Updated_At = DateTime.UtcNow;
        _context.Shipments.Add(shipment);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateShipment(Shipment shipment, int shipment_id){
        var shipment_to_update = await _context.Shipments.FindAsync(shipment_id);
        if (shipment_to_update == null)
        {
            return false;
        }

        shipment_to_update.Order_Date = shipment.Order_Date;
        shipment_to_update.Request_Date = shipment.Request_Date;
        shipment_to_update.Shipment_Date = shipment.Shipment_Date;
        shipment_to_update.Shipment_Type = shipment.Shipment_Type;
        shipment_to_update.Shipment_Status = shipment.Shipment_Status;
        shipment_to_update.Notes = shipment.Notes;
        shipment_to_update.Carrier_Code = shipment.Carrier_Code;
        shipment_to_update.Carrier_Description = shipment.Carrier_Code;
        shipment_to_update.Service_Code = shipment.Service_Code;
        shipment_to_update.Payment_Type = shipment.Payment_Type;
        shipment_to_update.Transfer_Mode = shipment.Transfer_Mode;
        shipment_to_update.Total_Package_Count = shipment.Total_Package_Count;
        shipment_to_update.Total_Package_Weight = shipment.Total_Package_Weight;
        shipment_to_update.Items = shipment.Items;
        shipment_to_update.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteShipment(int shipment_id){
        var shipment = await _context.Shipments.FindAsync(shipment_id);
        if (shipment != null)
        {
            _context.Remove(shipment);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface IShipmentService
{
    public Task<Shipment> ReadShipment(int shipment_id);

    public Task<IEnumerable<Shipment>> GetAllShipments(int page);
    public Task<bool> CreateShipment(Shipment shipment);
    public Task<bool> UpdateShipment(Shipment shipment, int shipment_id);
    public Task<bool> DeleteShipment(int shipment_id);
}