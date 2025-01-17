using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("cargohub/apikey")]
public class ApiKeyController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ApiKeyController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost("create/warehouses")]
    public async Task<IActionResult> GenerateWarehouseApiKeys()
    {
        var apikeys_raw = await ApiKeyService.GenerateWarehouseApiKeys(Request.Headers["APP_NAME"]!, _context);
        return Ok(apikeys_raw);
    }

    [HttpGet("test/apikeymatch")]
    public IActionResult TestMatchApiKey()
    {
        return Ok(ApiKeyService.HashApiKey(Request.Headers["API_KEY"]!));
    }

    [HttpDelete("delete/{warehouse_id}")]
    public async Task<IActionResult> DeleteApiKey(int warehouse_id)
    {
        var success = await ApiKeyService.DeleteApiKey(warehouse_id, _context);

        if (success) { return Ok("api_key deleted successfully."); }
        return BadRequest("Nothing to delete or failed");
    }
}
