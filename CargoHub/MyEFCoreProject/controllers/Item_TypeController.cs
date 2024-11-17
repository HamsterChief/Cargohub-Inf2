using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("item_type")]
[ApiController]
public class Item_TypeController : Controller
{
    private readonly IItem_TypeService _item_TypeService;

    public Item_TypeController(IItem_TypeService item_TypeService)
    {
        _item_TypeService = item_TypeService;
    }
}