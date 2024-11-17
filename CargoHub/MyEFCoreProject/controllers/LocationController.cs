using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("location")]
[ApiController]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
}