using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShipmentService : IShipmentService
{
    private DatabaseContext _context;

    public ShipmentService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
    // public async Task<Shipment> ReadShipment(int id){

    //     var shipment = await _context.Shipments.FindAsync();

    // }
}

    

public interface IShipmentService
{
    public Task<Shipment> ReadShipment(int id);
    public Task<bool> CreateShipment(Shipment shipment);
    public Task<bool> UpdateShipment(Shipment shipment, int id);
    public Task<bool> DeleteShipment(int id);
}
