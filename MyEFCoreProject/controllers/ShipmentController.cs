using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
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
    public async Task<IActionResult> ReadShipmentItems(int shipment_id)
    {
        var result = await _shipmentService.ReadShipmentItems(shipment_id);
        if (result.Count() != 0)
        {
            return Ok(result);
        }
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

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
    public async Task<IActionResult> ReadShipmentOrders(int shipment_id)
    {
        var result = await _shipmentService.ReadShipmentOrders(shipment_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

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
    public async Task<IActionResult> UpdateShipmentOrder([FromBody] Order order, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipmentOrder(order, shipment_id);
        if (result)
        {
            return Ok("Shipment updated succesfully.");
        }
        return BadRequest("Failed to update shipment");
    }

    [HttpPut("shipments/{shipment_id}/items")]
    public async Task<IActionResult> UpdateShipmentItems([FromBody] List<PropertyItem> items, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipmentItems(items, shipment_id);
        if (result)
        {
            return Ok("Shipment updated succesfully.");
        }
        return BadRequest("Failed to update shipment");
    }

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

    [HttpPut("shipments/Commit/{shipment_id}")]
    public async Task<IActionResult> CommitShipment(int shipment_id)
    {
        var result = await _shipmentService.CommitShipment(shipment_id);
        if (result)
        {
            return Ok("Shipment Commited");
        }
        return BadRequest("Failed to commit");
    }
}