using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class Item_GroupController : Controller
{
    private readonly IItem_GroupService _item_GroupService;
    private readonly IAuditLogService _auditLogService;

    public Item_GroupController(IItem_GroupService item_GroupService, IAuditLogService auditLogService)
    {
        _item_GroupService = item_GroupService;
        _auditLogService = auditLogService;
    }

    [HttpGet("item_groups/{item_group_id}")]
    public async Task<IActionResult> ReadItem_Group(int item_group_id)
    {
        var result = await _item_GroupService.ReadItem_Group(item_group_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching item_group", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching item_group", Request.Headers["API_KEY"]!);
        return NotFound($"No such item_group with Id: {item_group_id}");
    }

    [HttpGet("item_groups")]
    public async Task<IActionResult> ReadItem_Groups()
    {
        var result = await _item_GroupService.ReadItem_Groups();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple item_groups", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple item_groups", Request.Headers["API_KEY"]!);
        return NotFound("No item_groups found");
    }

    [HttpGet("item_groups/{item_group_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Group(int item_group_id)
    {
        List<Item> result = await _item_GroupService.ReadItemsForItem_Group(item_group_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for item_group", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items for item_group", Request.Headers["API_KEY"]!);
        return NotFound($"no items found for item_group with Id: {item_group_id}");
    }

    [HttpPost("item_groups")]
    public async Task<IActionResult> CreateItem_Group([FromBody] Item_Group item_group)
    {
        var result = await _item_GroupService.CreateItem_Group(item_group);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating item_group", Request.Headers["API_KEY"]!);
            return Ok("Item_group created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating item_group", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create item_group.");
    }

    [HttpPut("item_groups/{item_group_id}")]
    public async Task<IActionResult> UpdateItem_Group([FromBody] Item_Group item_group, int item_group_id)
    {
        var result = await _item_GroupService.UpdateItem_Group(item_group, item_group_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating item_group", Request.Headers["API_KEY"]!);
            return Ok("Item_group updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating item_group", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update item_group.");
    }

    [HttpDelete("item_groups/{item_group_id}")]
    public async Task<IActionResult> DeleteItem_Group(int item_group_id)
    {
        var result = await _item_GroupService.DeleteItem_Group(item_group_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting item_group", Request.Headers["API_KEY"]!);
            return Ok("Item_group deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting item_group", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete item_group.");
    }
}