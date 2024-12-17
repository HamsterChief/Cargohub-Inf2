using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class LocationController : Controller
{
    private readonly ILocationService _locationService;
    private readonly IAuditLogService _auditLogService;

    public LocationController(ILocationService locationService, IAuditLogService auditLogService)
    {
        _locationService = locationService;
        _auditLogService = auditLogService;
    }

    [HttpGet("locations/{location_id}")]
    public async Task<IActionResult> ReadLocation(int location_id)
    {
        var result = await _locationService.ReadLocation(location_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching location", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching location", Request.Headers["API_KEY"]!);
        return NotFound($"No such location with Id: {location_id}");
    }

    [HttpGet("locations")]
    public async Task<IActionResult> ReadLocations()
    {
        var result = await _locationService.ReadLocations();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple locations", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple locations", Request.Headers["API_KEY"]!);
        return NotFound("No locations found");
    }

    [HttpPost("locations")]
    public async Task<IActionResult> CreateLocation([FromBody] Location location)
    {
        var result = await _locationService.CreateLocation(location);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating location", Request.Headers["API_KEY"]!);
            return Ok("Location created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating location", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create location.");
    }

    [HttpPut("locations/{location_id}")]
    public async Task<IActionResult> UpdateLocation([FromBody] Location location, int location_id)
    {
        var result = await _locationService.UpdateLocation(location, location_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating location", Request.Headers["API_KEY"]!);
            return Ok("Location updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating location", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update location.");
    }

    [HttpDelete("locations/{location_id}")]
    public async Task<IActionResult> DeleteLocation(int location_id)
    {
        var result = await _locationService.DeleteLocation(location_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting location", Request.Headers["API_KEY"]!);
            return Ok("Location deleted succesfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting location", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete location.");
    }
}