using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("cargohub/apikey")]
public class ApiKeyController : ControllerBase
{
    private readonly ApiKeyService _apiKeyService;

    public ApiKeyController(ApiKeyService apiKeyService)
    {
        _apiKeyService = apiKeyService;
    }

    // [HttpPost("create")]
    // public async Task<IActionResult> CreateApiKey([FromBody] ApiKeyRequest request)
    // {
    //     var rawApiKey = await _apiKeyService.CreateAndSaveApiKeyAsync(
    //         request.AppName,
    //         request.Permissions);

    //     return Ok(new { ApiKey = rawApiKey });
    // }
}

public class ApiKeyRequest
{
    public string AppName { get; set; }
    public string Permissions { get; set; }
}

public class PermissionsDto
{
    public bool Read { get; set; }
    public bool Write { get; set; }

    public bool Update {get; set;}

    public bool Delete {get; set;}
}
