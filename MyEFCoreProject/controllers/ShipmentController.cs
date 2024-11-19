using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ShipmentController : Controller
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpGet("shipments/{shipment_id}")]
    public async Task<IActionResult> ReadShipment(int shipment_id)
    {
        var result = await _shipmentService.ReadShipment(shipment_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

    [HttpGet("shipments")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1)
    {
        if (page < 1)
        {
            return BadRequest("Page must be greater than 0.");
        }

        var results = await _shipmentService.GetAllShipments(page);
        return Ok(results);
    }

    [HttpGet("shipments/{shipment_id}/items")]

    [HttpPost("shipments")]
    public async Task<IActionResult> CreateShipment([FromBody] Shipment shipment)
    {
        var result = await _shipmentService.CreateShipment(shipment);
        if (result)
        {
            return Ok("Shipment created succesfully.");
        }
        return BadRequest("Failed to create shipment.");
    }

    [HttpGet("shipments/{shipment_id}/orders")]

    [HttpPut("shipments/{shipment_id}")]
    public async Task<IActionResult> UpdateShipment([FromBody] Shipment shipment, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipment(shipment, shipment_id);
        if (result)
        {
            return Ok("Shipment updated succesfully.");
        }
        return BadRequest("Failed to update shipment");
    }

    [HttpPut("shipments/{shipment_id}/orders")]

    [HttpPut("shipments/{shipment_id}/items")]

    [HttpDelete("shipments/{shipment_id}")]
    public async Task<IActionResult> DeleteShipment(int shipment_id)
    {
        var result = await _shipmentService.DeleteShipment(shipment_id);
        if (result)
        {
            return Ok("Shipment deleted succesfully.");
        }
        return BadRequest("Failed to delete shipment.");
    }
}