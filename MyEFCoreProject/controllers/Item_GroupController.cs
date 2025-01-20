using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class Item_GroupController : Controller
{
    private readonly IItem_GroupService _item_GroupService;

    public Item_GroupController(IItem_GroupService item_GroupService)
    {
        _item_GroupService = item_GroupService;
    }

    [HttpGet("item_groups/{item_group_id}")]
    public async Task<IActionResult> ReadItem_Group(int item_group_id)
    {
        var result = await _item_GroupService.ReadItem_Group(item_group_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such item_group with Id: {item_group_id}");
    }

    [HttpGet("item_groups")]
    public async Task<IActionResult> ReadItem_Groups()
    {
        var result = await _item_GroupService.ReadItem_Groups();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No item_groups found");
    }

    [HttpGet("item_groups/{item_group_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Group(int item_group_id)
    {
        List<Item> result = await _item_GroupService.ReadItemsForItem_Group(item_group_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no items found for item_group with Id: {item_group_id}");
    }

    [HttpPost("item_groups")]
    public async Task<IActionResult> CreateItem_Group([FromBody] Item_Group item_group)
    {
        var result = await _item_GroupService.CreateItem_Group(item_group);
        if (result)
        {
            return Ok("Item_group created successfully.");
        }
        return BadRequest("Failed to create item_group.");
    }

    [HttpPut("item_groups/{item_group_id}")]
    public async Task<IActionResult> UpdateItem_Group([FromBody] Item_Group item_group, int item_group_id)
    {
        var result = await _item_GroupService.UpdateItem_Group(item_group, item_group_id);
        if (result)
        {
            return Ok("Item_group updated successfully.");
        }
        return BadRequest("Failed to update item_group.");
    }

    [HttpDelete("item_groups/{item_group_id}")]
    public async Task<IActionResult> DeleteItem_Group(int item_group_id)
    {
        var result = await _item_GroupService.DeleteItem_Group(item_group_id);
        if (result)
        {
            return Ok("Item_group deleted succesfully.");
        }
        return BadRequest("Failed to delete item_group.");
    }
}