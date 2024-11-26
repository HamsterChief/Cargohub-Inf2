using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class ShipmentController : Controller
{
    private readonly IShipmentService _shipmentService;

    public ShipmentController(IShipmentService shipmentService)
    {
        _shipmentService = shipmentService;
    }

    [HttpGet("shipments/{id}")]
    public async Task<IActionResult> Read(int id){
        var result = await _shipmentService.ReadShipment(id);
        if (result != null){
                return Ok(result);
        }
        return NotFound($"No shipment with Id: {id}");
    }

    [HttpGet("shipments")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1)
    {
        if (page < 1)
        {
            return BadRequest("Page must be greater than 0.");
        }

        var results = await _shipmentService.GetAllShipments(page);
        return Ok(results);
    }

    [HttpPost("shipments")]
    public async Task<IActionResult> Create(Shipment shipment){
        var result = await _shipmentService.CreateShipment(shipment);
        if (result){
            return Ok("Shipment created succesfully.");
        }
        return BadRequest("Failed to create shipment.");
    }

    [HttpPut("shipments/{id}")]
    public async Task<IActionResult> Update(Shipment shipment, int id){
        var result = await _shipmentService.UpdateShipment(shipment, id);
        if (result){
            return Ok("Shipment updated succesfully.");
        }
        return BadRequest("Failed to update shipment");
    }

    [HttpDelete("shipments/{id}")]
    public async Task<IActionResult> Delete(int id){
        var result = await _shipmentService.DeleteShipment(id);
        if (result){
            return Ok("Shipment deleted succesfully.");
        }
        return BadRequest("Failed to delete shipment.");
    }

}