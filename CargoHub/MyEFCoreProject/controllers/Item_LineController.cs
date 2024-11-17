using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("item_line")]
[ApiController]
public class Item_LineController : Controller
{
    private readonly IItem_LineService _item_LineService;

    public Item_LineController(IItem_LineService item_LineService)
    {
        _item_LineService = item_LineService;
    }
}