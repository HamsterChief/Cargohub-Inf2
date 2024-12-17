using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class WarehouseController : Controller
{
    private readonly IWarehouseService _warehouseService;
    private readonly IAuditLogService _auditLogService;

    public WarehouseController(IWarehouseService warehouseService, IAuditLogService auditLogService)
    {
        _warehouseService = warehouseService;
        _auditLogService = auditLogService;
    }

    [HttpGet("warehouses/{warehouse_id}")]
    public async Task<IActionResult> ReadWarehouse(int warehouse_id)
    {
        var result = await _warehouseService.ReadWarehouse(warehouse_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching warehouse", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching warehouse", Request.Headers["API_KEY"]!);
        return NotFound($"No such warehouse with Id: {warehouse_id}");
    }

    [HttpGet("warehouses")]
    public async Task<IActionResult> ReadWarehouses()
    {
        var result = await _warehouseService.ReadWarehouses();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple warehouses", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple warehouses", Request.Headers["API_KEY"]!);
        return NotFound("No warehouses found");
    }

    [HttpGet("warehouses/{warehouse_id}/locations")]
    public async Task<IActionResult> ReadLocationsInWarehouse(int warehouse_id)
    {
        List<Location> result = await _warehouseService.ReadLocationsInWarehouse(warehouse_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching locations for warehouse", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching locations for warehouse", Request.Headers["API_KEY"]!);
        return NotFound($"no locations found for warehouse with Id: {warehouse_id}");
    }

    [HttpPost("warehouses")]
    public async Task<IActionResult> CreateWarehouse(Warehouse warehouse)
    {
        var result = await _warehouseService.CreateWarehouse(warehouse);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating warehouse", Request.Headers["API_KEY"]!);
            return Ok("Warehouse created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating warehouse", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create warehouse.");
    }

    [HttpPut("warehouses/{warehouse_id}")]
    public async Task<IActionResult> UpdateWarehouse(Warehouse warehouse, int warehouse_id)
    {
        var result = await _warehouseService.UpdateWarehouse(warehouse, warehouse_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating warehouse", Request.Headers["API_KEY"]!);
            return Ok("Warehouse updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating warehouse", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update warehouse.");
    }

    [HttpDelete("warehouses/{warehouse_id}")]
    public async Task<IActionResult> DeleteWarehouse(int warehouse_id)
    {
        var result = await _warehouseService.DeleteWarehouse(warehouse_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting warehouse", Request.Headers["API_KEY"]!);
            return Ok("Warehouse deleted successfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting warehouse", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete warehouse.");
    }
}