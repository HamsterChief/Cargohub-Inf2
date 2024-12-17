using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IAuditLogService _auditLogService;

    public OrderController(IOrderService orderService, IAuditLogService auditLogService)
    {
        _orderService = orderService;
        _auditLogService = auditLogService;
    }

    [HttpGet("orders/{order_id}")]
    public async Task<IActionResult> ReadOrder(int order_id)
    {
        var result = await _orderService.ReadOrder(order_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching order", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching order", Request.Headers["API_KEY"]!);
        return NotFound($"No such order with Id: {order_id}");
    }

    [HttpGet("orders")]
    public async Task<IActionResult> ReadOrders()
    {
        var result = await _orderService.ReadOrders();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple orders", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple orders", Request.Headers["API_KEY"]!);
        return NotFound("No orders found");
    }

    [HttpGet("orders/{order_id}/items")]
    public async Task<IActionResult> ReadItemsInOrder(int order_id)
    {
        List<Item> result = await _orderService.ReadItemsInOrder(order_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items in order", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items in order", Request.Headers["API_KEY"]!);
        return NotFound($"no items found in order with Id: {order_id}");
    }

    [HttpPost("orders")]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        var result = await _orderService.CreateOrder(order);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating order", Request.Headers["API_KEY"]!);
            return Ok("Order created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating order", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create order.");
    }

    [HttpPut("orders/{order_id}")]
    public async Task<IActionResult> UpdateOrder([FromBody] Order order, int order_id)
    {
        var result = await _orderService.UpdateOrder(order, order_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating order", Request.Headers["API_KEY"]!);
            return Ok("Order updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating order", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update order.");
    }

    [HttpPut("orders/{order_id}/items")]
    public async Task<IActionResult> UpdateItemsInOrder(int order_id, [FromBody] List<PropertyItem> updated_items)
    {
        var result = await _orderService.UpdateItemsInOrder(order_id, updated_items);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating items in order", Request.Headers["API_KEY"]!);
            return Ok("Items in order updated succesfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating items in order", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update items in order.");
    }

    [HttpDelete("orders/{order_id}")]
    public async Task<IActionResult> DeleteOrder(int order_id)
    {
        var result = await _orderService.DeleteOrder(order_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting order", Request.Headers["API_KEY"]!);
            return Ok("Order deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting order", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete order.");
    }
}