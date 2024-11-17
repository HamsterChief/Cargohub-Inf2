using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("order")]
[ApiController]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
}