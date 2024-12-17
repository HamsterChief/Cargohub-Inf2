using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("locations/{location_id}")]
    public async Task<IActionResult> ReadLocation(int location_id)
    {
        var result = await _locationService.ReadLocation(location_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such location with Id: {location_id}");
    }

    [HttpGet("locations")]
    public async Task<IActionResult> ReadLocations()
    {
        var result = await _locationService.ReadLocations();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No locations found");
    }

    [HttpPost("locations")]
    public async Task<IActionResult> CreateLocation([FromBody] Location location)
    {
        var result = await _locationService.CreateLocation(location);
        if (result)
        {
            return Ok("Location created successfully.");
        }
        return BadRequest("Failed to create location.");
    }

    [HttpPut("locations/{location_id}")]
    public async Task<IActionResult> UpdateLocation([FromBody] Location location, int location_id)
    {
        var result = await _locationService.UpdateLocation(location, location_id);
        if (result)
        {
            return Ok("Location updated successfully.");
        }
        return BadRequest("Failed to update location.");
    }

    [HttpDelete("locations/{location_id}")]
    public async Task<IActionResult> DeleteLocation(int location_id)
    {
        var result = await _locationService.DeleteLocation(location_id);
        if (result)
        {
            return Ok("Location deleted succesfully.");
        }
        return BadRequest("Failed to delete location.");
    }
}