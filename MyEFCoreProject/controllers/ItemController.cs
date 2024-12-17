using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IAuditLogService _auditLogService;

    public ItemController(IItemService itemService, IAuditLogService auditLogService)
    {
        _itemService = itemService;
        _auditLogService = auditLogService;
    }

    [HttpGet("items/{item_id}")]
    public async Task<IActionResult> ReadItem(string item_id)
    {
        var result = await _itemService.ReadItem(item_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching item", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching item", Request.Headers["API_KEY"]!);
        return NotFound($"No such item with Id: {item_id}");
    }

    [HttpGet("items")]
    public async Task<IActionResult> ReadItems()
    {
        var result = await _itemService.ReadItems();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple items", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple items", Request.Headers["API_KEY"]!);
        return NotFound("No items found");
    }

    [HttpGet("items/{item_id}/inventory")]
    public async Task<IActionResult> ReadInventoriesForItem(string item_id)
    {
        List<Inventory> result = await _itemService.ReadInventoriesForItem(item_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching inventories for item", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching inventories for item", Request.Headers["API_KEY"]!);
        return NotFound($"No inventories found for item with Id: {item_id}");
    }

    [HttpGet("items/{item_id}/inventory/totals")]
    public async Task<IActionResult> ReadInventoryTotalsForItem(string item_id)
    {
        if (await _itemService.ReadItem(item_id) != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching inventory totals for item", Request.Headers["API_KEY"]!);
            return Ok(await _itemService.ReadInventoryTotalsForItem(item_id));
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching inventory totals for item", Request.Headers["API_KEY"]!);
        return NotFound($"No such item with Id: {item_id}");
    }

    [HttpPost("items")]
    public async Task<IActionResult> CreateItem([FromBody] Item item)
    {
        var result = await _itemService.CreateItem(item);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating item", Request.Headers["API_KEY"]!);
            return Ok("Item created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating item", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create item.");
    }

    [HttpPut("items/{item_id}")]
    public async Task<IActionResult> UpdateItem([FromBody] Item item, string item_id)
    {
        var result = await _itemService.UpdateItem(item, item_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating item", Request.Headers["API_KEY"]!);
            return Ok("Item updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating item", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update item.");
    }

    [HttpDelete("items/{item_id}")]
    public async Task<IActionResult> DeleteItem(string item_id)
    {
        var result = await _itemService.DeleteItem(item_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting item", Request.Headers["API_KEY"]!);
            return Ok("Item deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD  REQUEST: Deleting item", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete item.");
    }
}