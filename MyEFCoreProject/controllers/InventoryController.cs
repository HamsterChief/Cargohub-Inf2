using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet("inventories/{inventory_id}")]
    public async Task<IActionResult> ReadInventory(int inventory_id)
    {
        var result = await _inventoryService.ReadInventory(inventory_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such inventory with Id: {inventory_id}");
    }

    [HttpGet("inventories")]
    public async Task<IActionResult> ReadInventories()
    {
        var result = await _inventoryService.ReadInventories();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No inventories found");
    }

    [HttpPost("inventories")]
    public async Task<IActionResult> CreateInventory([FromBody] Inventory inventory)
    {
        var result = await _inventoryService.CreateInventory(inventory);
        if (result)
        {
            return Ok("Inventory created successfully.");
        }
        return BadRequest("Failed to create inventory.");
    }

    [HttpPut("inventories/{inventory_id}")]
    public async Task<IActionResult> UpdateInventory([FromBody] Inventory inventory, int inventory_id)
    {
        var result = await _inventoryService.UpdateInventory(inventory, inventory_id);
        if (result)
        {
            return Ok("Inventory updated successfully.");
        }
        return BadRequest("Failed to update inventory.");
    }

    [HttpDelete("inventories/{inventory_id}")]
    public async Task<IActionResult> DeleteInventory(int inventory_id)
    {
        var result = await _inventoryService.DeleteInventory(inventory_id);
        if (result)
        {
            return Ok("Inventory deleted succesfully.");
        }
        return BadRequest("Failed to delete inventory.");
    }
}