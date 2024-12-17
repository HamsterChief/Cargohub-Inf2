using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class HomeController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Home()
    {
        return Ok();
    }
}