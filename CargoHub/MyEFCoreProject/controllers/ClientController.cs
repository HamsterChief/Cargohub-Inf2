using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

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
    

    [HttpGet("clients/{id}")]
    public async Task<IActionResult> Read(int id)
    {
        var result = await _clientService.ReadClient(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such client with Id: {id}");
    }

    [HttpPost("clients")]
    public async Task<IActionResult> Create([FromBody] Client client)
    {
        var result = await _clientService.CreateClient(client);
        if (result)
        {
            return Ok("Client created successfully.");
        }
        return BadRequest("Failed to create client.");
    }

    [HttpPut("clients/{id}")]
    public async Task<IActionResult> Update([FromBody] Client client, int id)
    {
        var result = await _clientService.UpdateClient(client, id);
        if (result)
        {
            return Ok("Client updated successfully.");
        }
        return BadRequest("Failed to update client.");
    }

    [HttpDelete("clients/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _clientService.DeleteClient(id);
        if (result)
        {
            return Ok("Client deleted succesfully.");
        }
        return BadRequest("Failed to delete client.");
    }

    // [HttpPost("import-clients")]
    // public async Task<IActionResult> ImportClients()
    // {
    //     try
    //     {
    //         var clientsJson = System.IO.File.ReadAllText("data/clients.json");

    //         var options = new JsonSerializerOptions
    //         {
    //             PropertyNameCaseInsensitive = true
    //         };

    //         // Deserialize naar een lijst van Dictionary<string, JsonElement>
    //         var clientsData = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(clientsJson, options);

    //         if (clientsData == null || !clientsData.Any())
    //         {
    //             return BadRequest("No clients found in the JSON file.");
    //         }

    //         var clients = new List<Client>();

    //         // Itereer door elk object in de JSON data en zet de datumvelden om
    //         foreach (var clientData in clientsData)
    //         {
    //             var client = new Client
    //             {
    //                 id = clientData["id"].GetInt32(),
    //                 name = clientData["name"].GetString(),
    //                 address = clientData["address"].GetString(),
    //                 city = clientData["city"].GetString(),
    //                 zip_code = clientData["zip_code"].GetString(),
    //                 province = clientData["province"].GetString(),
    //                 country = clientData["country"].GetString(),
    //                 contact_name = clientData["contact_name"].GetString(),
    //                 contact_phone = clientData["contact_phone"].GetString(),
    //                 contact_email = clientData["contact_email"].GetString(),
                    
    //                 // Parse de datum en verwijder de milliseconden
    //                 created_at = clientData["created_at"].ValueKind == JsonValueKind.String 
    //                                 ? DateTime.Parse(clientData["created_at"].GetString() ?? DateTime.UtcNow.ToString())
    //                                     .AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond))
    //                                 : DateTime.UtcNow.AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond)),
                    
    //                 updated_at = clientData["updated_at"].ValueKind == JsonValueKind.String 
    //                                 ? DateTime.Parse(clientData["updated_at"].GetString() ?? DateTime.UtcNow.ToString())
    //                                     .AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond))
    //                                 : DateTime.UtcNow.AddTicks(-(DateTime.UtcNow.Ticks % TimeSpan.TicksPerSecond))
    //             };

    //             clients.Add(client);
    //         }

    //         // Sla elke client op in de database
    //         foreach (var client in clients)
    //         {
    //             var result = await _clientService.CreateClient(client);
    //             if (!result)
    //             {
    //                 return BadRequest($"Failed to add client {client.name}.");
    //             }
    //         }

    //         return Ok("Clients imported and added successfully.");
    //     }
    //     catch (Exception ex)
    //     {
    //         // Log error (optioneel)
    //         return StatusCode(500, $"Internal server error: {ex.Message}");
    //     }
    // }
}