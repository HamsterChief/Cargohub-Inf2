using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class TransferController : Controller
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpGet("transfers/{id}")]
    public async Task<IActionResult> Read(int id)
    {
        
        var result = await _transferService.ReadTransfer(id);
        if (result != null){
            return Ok(result);
        }
        else {
            return NotFound($"No transfer with Id: {id}");
        }
    }

    [HttpGet("transfers")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1)
    {
        if (page < 1)
        {
            return BadRequest("Page must be greater than 0.");
        }

        var results = await _transferService.GetAllTransfers(page);
        return Ok(results);
    }


    [HttpPost("transfers")]
    public async Task<IActionResult> Create(Transfer transfer)
    {
        var result = await _transferService.CreateTransfer(transfer);
        if (result)
        {
            return Ok("Transfer created successfully.");
        }
        return BadRequest("Failed to create transfer.");
    }

    [HttpPut("transfers/{id}")]
    public async Task<IActionResult> Update(Transfer transfer, int id)
    {
        var result = await _transferService.UpdateTransfer(transfer, id);
        if (result)
        {
            return Ok("Transfer updated successfully.");
        }
        return BadRequest("Failed to update transfer.");
    }

    [HttpDelete("transfers/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _transferService.DeleteTransfer(id);
        if (result)
        {
            return Ok("Transfer deleted successfully.");
        }
        return BadRequest("Failed to delete transfer.");
    }
}
