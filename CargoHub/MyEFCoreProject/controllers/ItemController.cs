using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("item")]
[ApiController]
public class ItemController : Controller
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }
}