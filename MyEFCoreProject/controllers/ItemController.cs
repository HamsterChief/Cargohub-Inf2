using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ItemController : Controller
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("items/{item_id}")]
    public async Task<IActionResult> ReadItem(string item_id)
    {
        var result = await _itemService.ReadItem(item_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such item with Id: {item_id}");
    }

    [HttpGet("items")]
    public async Task<IActionResult> ReadItems()
    {
        var result = await _itemService.ReadItems();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No items found");
    }

    [HttpGet("items/{item_id}/inventory")]
    public async Task<IActionResult> ReadInventoriesForItem(string item_id)
    {
        List<Inventory> result = await _itemService.ReadInventoriesForItem(item_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"No inventories found for item with Id: {item_id}");
    }

    [HttpGet("items/{item_id}/inventory/totals")]
    public async Task<IActionResult> ReadInventoryTotalsForItem(string item_id)
    {
        if (await _itemService.ReadItem(item_id) != null)
        {
            return Ok(await _itemService.ReadInventoryTotalsForItem(item_id));
        }
        return NotFound($"No such item with Id: {item_id}");
    }

    [HttpPost("items")]
    public async Task<IActionResult> CreateItem([FromBody] Item item)
    {
        var result = await _itemService.CreateItem(item);
        if (result)
        {
            return Ok("Item created successfully.");
        }
        return BadRequest("Failed to create item.");
    }

    [HttpPut("items/{item_id}")]
    public async Task<IActionResult> UpdateItem([FromBody] Item item, string item_id)
    {
        var result = await _itemService.UpdateItem(item, item_id);
        if (result)
        {
            return Ok("Item updated successfully.");
        }
        return BadRequest("Failed to update item.");
    }

    [HttpDelete("items/{item_id}")]
    public async Task<IActionResult> DeleteItem(string item_id)
    {
        var result = await _itemService.DeleteItem(item_id);
        if (result)
        {
            return Ok("Item deleted succesfully.");
        }
        return BadRequest("Failed to delete item.");
    }
}