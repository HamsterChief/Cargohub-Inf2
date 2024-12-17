using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class TransferController : Controller
{
    private readonly ITransferService _transferService;
    private readonly IAuditLogService _auditLogService;

    public TransferController(ITransferService transferService, IAuditLogService auditLogService)
    {
        _transferService = transferService;
        _auditLogService = auditLogService;
    }

    [HttpGet("transfers/{transfer_id}")]
    public async Task<IActionResult> ReadTransfer(int transfer_id)
    {
        var result = await _transferService.ReadTransfer(transfer_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching transfer", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching transfer", Request.Headers["API_KEY"]!);
        return NotFound($"No such transfer with Id: {transfer_id}");
    }

    [HttpGet("transfers")]
    public async Task<IActionResult> ReadTransfers()
    {
        var result = await _transferService.ReadTransfers();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple transfers", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple transfers", Request.Headers["API_KEY"]!);
        return NotFound("No transfers found");
    }

    [HttpGet("transfers/{transfer_id}/items")]
    public async Task<IActionResult> ReadTransferItems(int transfer_id)
    {
        var result = await _transferService.ReadTransferItems(transfer_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for transfer", Request.Headers["API_KEY"]!);
            return Ok("Transfer updated succesfully.");
        }
        await _auditLogService.LogActionAsync("GET", "400 BAD REQUEST: Fetching items for transfer", Request.Headers["API_KEY"]!);
        return BadRequest($"No items found for transfer with Id: {transfer_id}");
    }

    [HttpPost("transfers")]
    public async Task<IActionResult> CreateTransfer(Transfer transfer)
    {
        var result = await _transferService.CreateTransfer(transfer);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating transfer", Request.Headers["API_KEY"]!);
            return Ok("Transfer created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating transfer", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create transfer.");
    }

    [HttpPut("transfers/{transfer_id}")]
    public async Task<IActionResult> UpdateTransfer(Transfer transfer, int transfer_id)
    {
        var result = await _transferService.UpdateTransfer(transfer, transfer_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating transfer", Request.Headers["API_KEY"]!);
            return Ok("Transfer updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating transfer", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update transfer.");
    }

    [HttpDelete("transfers/{transfer_id}")]
    public async Task<IActionResult> DeleteTransfer(int transfer_id)
    {
        var result = await _transferService.DeleteTransfer(transfer_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting transfer", Request.Headers["API_KEY"]!);
            return Ok("Transfer deleted successfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting transfer", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete transfer.");
    }
}