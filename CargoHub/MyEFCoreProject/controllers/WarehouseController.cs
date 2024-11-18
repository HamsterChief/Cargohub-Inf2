using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class WarehouseController : Controller
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet("warehouses/{id?}")]
    public async Task<IActionResult> Read(int? id)
    {
        if (id.HasValue){
            var result = await _warehouseService.ReadWarehouse(id.Value);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No warehouse with Id: {id}");
        }
        else
        {
            var result = await _warehouseService.GetAllWarehouses();
            return Ok(result);
        }
    }

    [HttpPost("warehouses")]
    public async Task<IActionResult> Create(Warehouse warehouse)
    {
        var result = await _warehouseService.CreateWarehouse(warehouse);
        if (result)
        {
            return Ok("Warehouse created successfully.");
        }
        return BadRequest("Failed to create warehouse.");
    }

    [HttpPut("warehouses/{id}")]
    public async Task<IActionResult> Update(Warehouse warehouse, int id)
    {
        var result = await _warehouseService.UpdateWarehouse(warehouse, id);
        if (result)
        {
            return Ok("Warehouse updated successfully.");
        }
        return BadRequest("Failed to update warehouse.");
    }

    [HttpDelete("warehouses/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _warehouseService.DeleteWarehouse(id);
        if (result)
        {
            return Ok("Warehouse deleted successfully.");
        }
        return BadRequest("Failed to delete warehouse.");
    }
}
