using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ShipmentController : Controller
{
    private readonly IShipmentService _shipmentService;
    private readonly IAuditLogService _auditLogService;

    public ShipmentController(IShipmentService shipmentService, IAuditLogService auditLogService)
    {
        _shipmentService = shipmentService;
        _auditLogService = auditLogService;
    }

    [HttpGet("shipments/{shipment_id}")]
    public async Task<IActionResult> ReadShipment(int shipment_id)
    {
        var result = await _shipmentService.ReadShipment(shipment_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching shipment", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching shipment", Request.Headers["API_KEY"]!);
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

    [HttpGet("shipments")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1)
    {
        if (page < 1)
        {
            await _auditLogService.LogActionAsync("GET", "400 BAD REQUEST: Fetching multiple shipments", Request.Headers["API_KEY"]!);
            return BadRequest("Page must be greater than 0.");
        }

        var results = await _shipmentService.GetAllShipments(page);
        await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple shipments", Request.Headers["API_KEY"]!);
        return Ok(results);
    }

    [HttpGet("shipments/{shipment_id}/items")]
    public async Task<IActionResult> ReadShipmentItems(int shipment_id)
    {
        var result = await _shipmentService.ReadShipmentItems(shipment_id);
        if (result.Count() != 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for shipment", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items for shipment", Request.Headers["API_KEY"]!);
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

    [HttpPost("shipments")]
    public async Task<IActionResult> CreateShipment([FromBody] Shipment shipment)
    {
        var result = await _shipmentService.CreateShipment(shipment);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating shipment", Request.Headers["API_KEY"]!);
            return Ok("Shipment created succesfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating shipment", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create shipment.");
    }

    [HttpGet("shipments/{shipment_id}/orders")]
    public async Task<IActionResult> ReadShipmentOrders(int shipment_id)
    {
        var result = await _shipmentService.ReadShipmentOrders(shipment_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching orders for shipment", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching orders for shipment", Request.Headers["API_KEY"]!);
        return NotFound($"No such shipment with Id: {shipment_id}");
    }

    [HttpPut("shipments/{shipment_id}")]
    public async Task<IActionResult> UpdateShipment([FromBody] Shipment shipment, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipment(shipment, shipment_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating shipment", Request.Headers["API_KEY"]!);
            return Ok("Shipment updated succesfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating shipment", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update shipment");
    }

    [HttpPut("shipments/{shipment_id}/orders")]
    public async Task<IActionResult> UpdateShipmentOrder([FromBody] Order order, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipmentOrder(order, shipment_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating order in shipment", Request.Headers["API_KEY"]!);
            return Ok("Shipment updated succesfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating order in shipment", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update shipment");
    }

    [HttpPut("shipments/{shipment_id}/items")]
    public async Task<IActionResult> UpdateShipmentItems([FromBody] List<PropertyItem> items, int shipment_id)
    {
        var result = await _shipmentService.UpdateShipmentItems(items, shipment_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating items in shipment", Request.Headers["API_KEY"]!);
            return Ok("Shipment updated succesfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating items in shipment", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update shipment");
    }

    [HttpDelete("shipments/{shipment_id}")]
    public async Task<IActionResult> DeleteShipment(int shipment_id)
    {
        var result = await _shipmentService.DeleteShipment(shipment_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting shipment", Request.Headers["API_KEY"]!);
            return Ok("Shipment deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting shipment", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete shipment.");
    }
}