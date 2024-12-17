using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IAuditLogService _auditLogService;

    public InventoryController(IInventoryService inventoryService, IAuditLogService auditLogService)
    {
        _inventoryService = inventoryService;
        _auditLogService = auditLogService;
    }

    [HttpGet("inventories/{inventory_id}")]
    public async Task<IActionResult> ReadInventory(int inventory_id)
    {
        var result = await _inventoryService.ReadInventory(inventory_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching inventory", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching inventory", Request.Headers["API_KEY"]!);
        return NotFound($"No such inventory with Id: {inventory_id}");
    }

    [HttpGet("inventories")]
    public async Task<IActionResult> ReadInventories()
    {
        var result = await _inventoryService.ReadInventories();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple inventories", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple inventories", Request.Headers["API_KEY"]!);
        return NotFound("No inventories found");
    }

    [HttpPost("inventories")]
    public async Task<IActionResult> CreateInventory([FromBody] Inventory inventory)
    {
        var result = await _inventoryService.CreateInventory(inventory);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating inventory", Request.Headers["API_KEY"]!);
            return Ok("Inventory created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating inventory", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create inventory.");
    }

    [HttpPut("inventories/{inventory_id}")]
    public async Task<IActionResult> UpdateInventory([FromBody] Inventory inventory, int inventory_id)
    {
        var result = await _inventoryService.UpdateInventory(inventory, inventory_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating inventory", Request.Headers["API_KEY"]!);
            return Ok("Inventory updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating inventory", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update inventory.");
    }

    [HttpDelete("inventories/{inventory_id}")]
    public async Task<IActionResult> DeleteInventory(int inventory_id)
    {
        var result = await _inventoryService.DeleteInventory(inventory_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting inventory", Request.Headers["API_KEY"]!);
            return Ok("Inventory deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting inventory", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete inventory.");
    }
}