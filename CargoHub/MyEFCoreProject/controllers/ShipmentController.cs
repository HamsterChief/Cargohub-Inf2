using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("shipment")]
[ApiController]
public class ShipmentController : Controller
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }
}