using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class Item_LineController : Controller
{
    private readonly IItem_LineService _item_LineService;
    private readonly IAuditLogService _auditLogService;

    public Item_LineController(IItem_LineService item_LineService, IAuditLogService auditLogService)
    {
        _item_LineService = item_LineService;
        _auditLogService = auditLogService;
    }

    [HttpGet("item_lines/{item_line_id}")]
    public async Task<IActionResult> ReadItem_Line(int item_line_id)
    {
        var result = await _item_LineService.ReadItem_Line(item_line_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching item_line", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching item_line", Request.Headers["API_KEY"]!);
        return NotFound($"No such item_line with Id: {item_line_id}");
    }

    [HttpGet("item_lines")]
    public async Task<IActionResult> ReadItem_Lines()
    {
        var result = await _item_LineService.ReadItem_Lines();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple item_lines", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple item_lines", Request.Headers["API_KEY"]!);
        return NotFound("No item_lines found");
    }

    [HttpGet("item_lines/{item_line_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Line(int item_line_id)
    {
        List<Item> result = await _item_LineService.ReadItemsForItem_Line(item_line_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for item_line", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items for item_line", Request.Headers["API_KEY"]!);
        return NotFound($"no items found for item_line with Id: {item_line_id}");
    }

    [HttpPost("item_lines")]
    public async Task<IActionResult> CreateItem_Line([FromBody] Item_Line item_line)
    {
        var result = await _item_LineService.CreateItem_Line(item_line);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating item_line", Request.Headers["API_KEY"]!);
            return Ok("Item_line created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating item_line", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create item_line.");
    }

    [HttpPut("item_lines/{item_line_id}")]
    public async Task<IActionResult> UpdateItem_Line([FromBody] Item_Line item_line, int item_line_id)
    {
        var result = await _item_LineService.UpdateItem_Line(item_line, item_line_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating item_line", Request.Headers["API_KEY"]!);
            return Ok("Item_line updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating item_line", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update item_line.");
    }

    [HttpDelete("item_lines/{item_line_id}")]
    public async Task<IActionResult> DeleteItem_Line(int item_line_id)
    {
        var result = await _item_LineService.DeleteItem_Line(item_line_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting item_line", Request.Headers["API_KEY"]!);
            return Ok("Item_line deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting item_line", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete item_line.");
    }
}