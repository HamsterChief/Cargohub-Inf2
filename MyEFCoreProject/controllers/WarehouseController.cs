using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class WarehouseController : Controller
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet("warehouses/{warehouse_id}")]
    public async Task<IActionResult> ReadWarehouse(int warehouse_id)
    {
        var result = await _warehouseService.ReadWarehouse(warehouse_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such warehouse with Id: {warehouse_id}");
    }

    [HttpGet("warehouses")]
    public async Task<IActionResult> ReadWarehouses()
    {
        var result = await _warehouseService.ReadWarehouses();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No warehouses found");
    }

    [HttpGet("warehouses/{warehouse_id}/locations")]
    public async Task<IActionResult> ReadLocationsInWarehouse(int warehouse_id)
    {
        List<Location> result = await _warehouseService.ReadLocationsInWarehouse(warehouse_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no locations found for warehouse with Id: {warehouse_id}");
    }

    [HttpPost("warehouses")]
    public async Task<IActionResult> CreateWarehouse(Warehouse warehouse)
    {
        var result = await _warehouseService.CreateWarehouse(warehouse);
        if (result)
        {
            return Ok("Warehouse created successfully.");
        }
        return BadRequest("Failed to create warehouse.");
    }

    [HttpPut("warehouses/{warehouse_id}")]
    public async Task<IActionResult> UpdateWarehouse(Warehouse warehouse, int warehouse_id)
    {
        var result = await _warehouseService.UpdateWarehouse(warehouse, warehouse_id);
        if (result)
        {
            return Ok("Warehouse updated successfully.");
        }
        return BadRequest("Failed to update warehouse.");
    }

    [HttpDelete("warehouses/{warehouse_id}")]
    public async Task<IActionResult> DeleteWarehouse(int warehouse_id)
    {
        var result = await _warehouseService.DeleteWarehouse(warehouse_id);
        if (result)
        {
            return Ok("Warehouse deleted successfully.");
        }
        return BadRequest("Failed to delete warehouse.");
    }
}