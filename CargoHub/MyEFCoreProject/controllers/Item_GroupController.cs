using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("item_group")]
[ApiController]
public class Item_GroupController : Controller
{
    private readonly IItem_GroupService _item_GroupService;

    public Item_GroupController(IItem_GroupService item_GroupService)
    {
        _item_GroupService = item_GroupService;
    }
}