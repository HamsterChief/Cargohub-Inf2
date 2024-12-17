using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class Item_TypeController : Controller
{
    private readonly IItem_TypeService _item_TypeService;

    public Item_TypeController(IItem_TypeService item_TypeService)
    {
        _item_TypeService = item_TypeService;
    }

    [HttpGet("item_types/{item_type_id}")]
    public async Task<IActionResult> ReadItem_Type(int item_type_id)
    {
        var result = await _item_TypeService.ReadItem_Type(item_type_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such item_type with Id: {item_type_id}");
    }

    [HttpGet("item_types")]
    public async Task<IActionResult> ReadItem_Types()
    {
        var result = await _item_TypeService.ReadItem_Types();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No item_types found");
    }

    [HttpGet("item_types/{item_type_id}/items")]
    public async Task<IActionResult> ReadItemsForItem_Type(int item_type_id)
    {
        List<Item> result = await _item_TypeService.ReadItemsForItem_Type(item_type_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no items found for item_type with Id: {item_type_id}");
    }

    [HttpPost("item_types")]
    public async Task<IActionResult> CreateItem_Type([FromBody] Item_Type item_type)
    {
        var result = await _item_TypeService.CreateItem_Type(item_type);
        if (result)
        {
            return Ok("Item_type created successfully.");
        }
        return BadRequest("Failed to create item_type.");
    }

    [HttpPut("item_types/{item_type_id}")]
    public async Task<IActionResult> UpdateItem_Type([FromBody] Item_Type item_type, int item_type_id)
    {
        var result = await _item_TypeService.UpdateItem_Type(item_type, item_type_id);
        if (result)
        {
            return Ok("Item_type updated successfully.");
        }
        return BadRequest("Failed to update item_type.");
    }

    [HttpDelete("item_types/{item_type_id}")]
    public async Task<IActionResult> DeleteItem_Type(int item_type_id)
    {
        var result = await _item_TypeService.DeleteItem_Type(item_type_id);
        if (result)
        {
            return Ok("Item_type deleted succesfully.");
        }
        return BadRequest("Failed to delete item_type.");
    }
}