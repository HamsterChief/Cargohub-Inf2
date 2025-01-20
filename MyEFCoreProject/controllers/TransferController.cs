using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class TransferController : Controller
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpGet("transfers/{transfer_id}")]
    public async Task<IActionResult> ReadTransfer(int transfer_id)
    {
        var result = await _transferService.ReadTransfer(transfer_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such transfer with Id: {transfer_id}");
    }

    [HttpGet("transfers")]
    public async Task<IActionResult> ReadTransfers()
    {
        var result = await _transferService.ReadTransfers();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No clients found");
    }

    [HttpGet("transfers/{transfer_id}/items")]
    public async Task<IActionResult> ReadTransferItems(int shipment_id)
    {
        var result = await _transferService.ReadTransferItems(shipment_id);
        if (result != null)
        {
            return Ok("Shipment updated succesfully.");
        }
        return BadRequest("Failed to update shipment");
    }

    [HttpPost("transfers")]
    public async Task<IActionResult> CreateTransfer(Transfer transfer)
    {
        var result = await _transferService.CreateTransfer(transfer);
        if (result)
        {
            return Ok("Transfer created successfully.");
        }
        return BadRequest("Failed to create transfer.");
    }

    [HttpPut("transfers/{transfer_id}")]
    public async Task<IActionResult> UpdateTransfer(Transfer transfer, int transfer_id)
    {
        var result = await _transferService.UpdateTransfer(transfer, transfer_id);
        if (result)
        {
            return Ok("Transfer updated successfully.");
        }
        return BadRequest("Failed to update transfer.");
    }

    [HttpDelete("transfers/{transfer_id}")]
    public async Task<IActionResult> DeleteTransfer(int transfer_id)
    {
        var result = await _transferService.DeleteTransfer(transfer_id);
        if (result)
        {
            return Ok("Transfer deleted successfully.");
        }
        return BadRequest("Failed to delete transfer.");
    }

    [HttpPut("transfers/Commit/{transfer_id}")]
    public async Task<IActionResult> CommitTransfer(int transfer_id)
    {
        var result = await _transferService.CommitTransfer(transfer_id);
        if (result)
        {
            return Ok("Transfer Commited");
        }
        return BadRequest("Failed to commit");
    }
}