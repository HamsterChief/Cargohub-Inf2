using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ClientController : Controller
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet("clients/{client_id}")]
    public async Task<IActionResult> ReadClient(int client_id)
    {
        var result = await _clientService.ReadClient(client_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such client with Id: {client_id}");
    }

    [HttpGet("clients")]
    public async Task<IActionResult> ReadClients()
    {
        var result = await _clientService.ReadClients();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No clients found");
    }

    [HttpGet("clients/{client_id}/orders")]

    [HttpPost("clients")]
    public async Task<IActionResult> CreateClient([FromBody] Client client)
    {
        var result = await _clientService.CreateClient(client);
        if (result)
        {
            return Ok("Client created successfully.");
        }
        return BadRequest("Failed to create client.");
    }

    [HttpPut("clients/{client_id}")]
    public async Task<IActionResult> UpdateClient([FromBody] Client client, int client_id)
    {
        var result = await _clientService.UpdateClient(client, client_id);
        if (result)
        {
            return Ok("Client updated successfully.");
        }
        return BadRequest("Failed to update client.");
    }

    [HttpDelete("clients/{client_id}")]
    public async Task<IActionResult> DeleteClient(int client_id)
    {
        var result = await _clientService.DeleteClient(client_id);
        if (result)
        {
            return Ok("Client deleted succesfully.");
        }
        return BadRequest("Failed to delete client.");
    }
}