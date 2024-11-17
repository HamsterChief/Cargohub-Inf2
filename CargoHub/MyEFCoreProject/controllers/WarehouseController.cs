using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("warehouse")]
[ApiController]
public class WarehouseController : Controller
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }
}