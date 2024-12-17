using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("orders/{order_id}")]
    public async Task<IActionResult> ReadOrder(int order_id)
    {
        var result = await _orderService.ReadOrder(order_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such order with Id: {order_id}");
    }

    [HttpGet("orders")]
    public async Task<IActionResult> ReadOrders()
    {
        var result = await _orderService.ReadOrders();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No orders found");
    }

    [HttpGet("orders/{order_id}/items")]
    public async Task<IActionResult> ReadItemsInOrder(int order_id)
    {
        List<Item> result = await _orderService.ReadItemsInOrder(order_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no items found in order with Id: {order_id}");
    }

    [HttpPost("orders")]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        var result = await _orderService.CreateOrder(order);
        if (result)
        {
            return Ok("Order created successfully.");
        }
        return BadRequest("Failed to create order.");
    }

    [HttpPut("orders/{order_id}")]
    public async Task<IActionResult> UpdateOrder([FromBody] Order order, int order_id)
    {
        var result = await _orderService.UpdateOrder(order, order_id);
        if (result)
        {
            return Ok("Order updated successfully.");
        }
        return BadRequest("Failed to update order.");
    }

    [HttpPut("orders/{order_id}/items")]
    public async Task<IActionResult> UpdateItemsInOrder(int order_id, [FromBody] List<PropertyItem> updated_items)
    {
        var result = await _orderService.UpdateItemsInOrder(order_id, updated_items);
        if (result)
        {
            return Ok("Items in order updated succesfully.");
        }
        return BadRequest("Failed to update items in order.");
    }

    [HttpDelete("orders/{order_id}")]
    public async Task<IActionResult> DeleteOrder(int order_id)
    {
        var result = await _orderService.DeleteOrder(order_id);
        if (result)
        {
            return Ok("Order deleted succesfully.");
        }
        return BadRequest("Failed to delete order.");
    }
}