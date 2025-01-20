using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class Item_LineController : Controller
{
    private readonly IItem_LineService _item_LineService;

    public Item_LineController(IItem_LineService item_LineService)
    {
        _item_LineService = item_LineService;
    }

    [HttpGet("item_lines/{item_line_id}")]
    public async Task<IActionResult> ReadItem_Line(int item_line_id)
    {
        var result = await _item_LineService.ReadItem_Line(item_line_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such item_line with Id: {item_line_id}");
    }

    [HttpGet("item_lines")]
    public async Task<IActionResult> ReadItem_Lines()
    {
        var result = await _item_LineService.ReadItem_Lines();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No item_lines found");
    }

    [HttpGet("item_lines/{item_line_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Line(int item_line_id)
    {
        List<Item> result = await _item_LineService.ReadItemsForItem_Line(item_line_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no items found for item_line with Id: {item_line_id}");
    }

    [HttpPost("item_lines")]
    public async Task<IActionResult> CreateItem_Line([FromBody] Item_Line item_line)
    {
        var result = await _item_LineService.CreateItem_Line(item_line);
        if (result)
        {
            return Ok("Item_line created successfully.");
        }
        return BadRequest("Failed to create item_line.");
    }

    [HttpPut("item_lines/{item_line_id}")]
    public async Task<IActionResult> UpdateItem_Line([FromBody] Item_Line item_line, int item_line_id)
    {
        var result = await _item_LineService.UpdateItem_Line(item_line, item_line_id);
        if (result)
        {
            return Ok("Item_line updated successfully.");
        }
        return BadRequest("Failed to update item_line.");
    }

    [HttpDelete("item_lines/{item_line_id}")]
    public async Task<IActionResult> DeleteItem_Line(int item_line_id)
    {
        var result = await _item_LineService.DeleteItem_Line(item_line_id);
        if (result)
        {
            return Ok("Item_line deleted succesfully.");
        }
        return BadRequest("Failed to delete item_line.");
    }
}