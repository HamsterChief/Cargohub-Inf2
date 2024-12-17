using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class Item_TypeController : Controller
{
    private readonly IItem_TypeService _item_TypeService;
    private readonly IAuditLogService _auditLogService;

    public Item_TypeController(IItem_TypeService item_TypeService, IAuditLogService auditLogService)
    {
        _item_TypeService = item_TypeService;
        _auditLogService = auditLogService;
    }

    [HttpGet("item_types/{item_type_id}")]
    public async Task<IActionResult> ReadItem_Type(int item_type_id)
    {
        var result = await _item_TypeService.ReadItem_Type(item_type_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching item_type", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching item_type", Request.Headers["API_KEY"]!);
        return NotFound($"No such item_type with Id: {item_type_id}");
    }

    [HttpGet("item_types")]
    public async Task<IActionResult> ReadItem_Types()
    {
        var result = await _item_TypeService.ReadItem_Types();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple item_types", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple item_types", Request.Headers["API_KEY"]!);
        return NotFound("No item_types found");
    }

    [HttpGet("item_types/{item_type_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Type(int item_type_id)
    {
        List<Item> result = await _item_TypeService.ReadItemsForItem_Type(item_type_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for item_type", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items for item_type", Request.Headers["API_KEY"]!);
        return NotFound($"no items found for item_type with Id: {item_type_id}");
    }

    [HttpPost("item_types")]
    public async Task<IActionResult> CreateItem_Type([FromBody] Item_Type item_type)
    {
        var result = await _item_TypeService.CreateItem_Type(item_type);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating item_type", Request.Headers["API_KEY"]!);
            return Ok("Item_type created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating item_type", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create item_type.");
    }

    [HttpPut("item_types/{item_type_id}")]
    public async Task<IActionResult> UpdateItem_Type([FromBody] Item_Type item_type, int item_type_id)
    {
        var result = await _item_TypeService.UpdateItem_Type(item_type, item_type_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating item_type", Request.Headers["API_KEY"]!);
            return Ok("Item_type updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating item_type", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update item_type.");
    }

    [HttpDelete("item_types/{item_type_id}")]
    public async Task<IActionResult> DeleteItem_Type(int item_type_id)
    {
        var result = await _item_TypeService.DeleteItem_Type(item_type_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting item_type", Request.Headers["API_KEY"]!);
            return Ok("Item_type deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting item_type", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete item_type.");
    }
}