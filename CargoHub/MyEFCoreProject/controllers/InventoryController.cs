using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("inventory")]
[ApiController]
public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public 
}