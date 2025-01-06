using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TransferService : ITransferService
{
    private readonly DatabaseContext _context;
    private readonly IAuditLogService _auditLogService;

    public TransferService(DatabaseContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    public async Task<ServiceResult> ReadTransfer(int transfer_id, string api_key)
    {
        try
        {
            var transfer = await _context.Transfers.FindAsync(transfer_id);

            if (transfer == null)
            {
                await _auditLogService.LogActionAsync("GET", $"404 NOT FOUND: No such transfer with id: {transfer_id}", api_key);
                return new ServiceResult { StatusCode = 404, ErrorMessage = $"No such transfer with id: {transfer_id}" };
            }

            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching transfer", api_key);
            return new ServiceResult { Object = transfer, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("GET", $"500 INTERNAL SERVER ERROR: Failed to fetch transfer with id {transfer_id} - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public async Task<ServiceResult> ReadTransfers(string api_key)
    {
        try
        {
            var transfers = await _context.Transfers.ToListAsync();

            if (!transfers.Any())
            {
                await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: No transfers found", api_key);
                return new ServiceResult { StatusCode = 404, ErrorMessage = "No transfers found" };
            }

            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple transfers", api_key);
            return new ServiceResult { Object = transfers, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("GET", $"500 INTERNAL SERVER ERROR: Failed to Fetch multiple transfers - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public async Task<ServiceResult> ReadTransferItems(int transfer_id, string api_key)
    {
        try
        {
            var transfer = await _context.Transfers.FindAsync(transfer_id);

            if (transfer == null)
            {
                await _auditLogService.LogActionAsync("GET", $"404 NOT FOUND: Transfer not found with id {transfer_id}", api_key);
                return new ServiceResult { StatusCode = 404, ErrorMessage = $"Transfer not found with id {transfer_id}" };
            }

            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items in transfer", api_key);
            return new ServiceResult { Object = transfer.Items, StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("GET", $"500 INTERNAL SERVER ERROR: Failed to fetch items in transfer - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public async Task<ServiceResult> CreateTransfer(Transfer transfer, string api_key)
    {
        try
        {
            if (_context.Transfers.Any(x => x.Id == transfer.Id))
            {
                await _auditLogService.LogActionAsync("POST", $"409 ALREADY EXISTS: Id {transfer.Id} already in use", api_key);
                return new ServiceResult { StatusCode = 409, ErrorMessage = $"Id {transfer.Id} already in use" };
            }

            transfer.Created_At = DateTime.UtcNow;
            transfer.Updated_At = DateTime.UtcNow;
            _context.Transfers.Add(transfer);
            int n = await _context.SaveChangesAsync();

            if (n == 0)
            {
                await _auditLogService.LogActionAsync("POST", "500 INTERNAL SERVER ERROR: Failed to create transfer", api_key);
                return new ServiceResult { StatusCode = 500, ErrorMessage = "Failed to create transfer, please try again" };
            }

            await _auditLogService.LogActionAsync("POST", "200 OK: Transfer created succesfully", api_key );
            return new ServiceResult { StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("POST", $"500 INTERNAL SERVER ERROR: Failed to create transfer with id {transfer.Id} - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public async Task<ServiceResult> UpdateTransfer(Transfer transfer, int transfer_id, string api_key)
    {
        try
        {
            var existingTransfer = await _context.Transfers.FindAsync(transfer_id);
            if (existingTransfer == null)
            {
                await _auditLogService.LogActionAsync("PUT", $"404 NOT FOUND: Transfer not found with id {transfer_id}", api_key);
                return new ServiceResult { StatusCode = 404, ErrorMessage = $"Transfer not found with id {transfer_id}" };
            }

            existingTransfer.Reference = transfer.Reference;
            existingTransfer.Transfer_From = transfer.Transfer_From;
            existingTransfer.Transfer_To = transfer.Transfer_To;
            existingTransfer.Transfer_Status = transfer.Transfer_Status;
            existingTransfer.Items = transfer.Items;
            existingTransfer.Updated_At = DateTime.UtcNow;
            int n = await _context.SaveChangesAsync();

            if (n == 0)
            {
                await _auditLogService.LogActionAsync("PUT", $"500 INTERNAL SERVER ERROR: Failed to update transfer with id {transfer_id}", api_key);
                return new ServiceResult { StatusCode = 500, ErrorMessage = $"Failed to update transfer, please try again with id {transfer_id}" };
            }

            await _auditLogService.LogActionAsync("PUT", "200 OK: Updated transfer succesfully", api_key);
            return new ServiceResult { StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("POST", $"500 INTERNAL SERVER ERROR: Failed to update transfer with id {transfer.Id} - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }

    public async Task<ServiceResult> DeleteTransfer(int transfer_id, string api_key)
    {
        try
        {
            var transfer = await _context.Transfers.FindAsync(transfer_id);
            if (transfer == null)
            {
                await _auditLogService.LogActionAsync("DELETE", $"400 BADREQUEST: Transfer with id {transfer_id} already not in database", api_key);
                return new ServiceResult { StatusCode = 400, ErrorMessage = $"Transfer with id {transfer_id} already not in database" };
            }
            _context.Transfers.Remove(transfer);
            int n = await _context.SaveChangesAsync();
            
            if (n == 0)
            {
                await _auditLogService.LogActionAsync("DELETE", $"500 INTERNAL SERVER ERROR: Failed to delete transfer with id {transfer_id}", api_key);
                return new ServiceResult { StatusCode = 500, ErrorMessage = $"Failed to delete transfer with id {transfer_id}, please try again" };
            }

            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleted transfer succesfully", api_key);
            return new ServiceResult { StatusCode = 200 };
        }
        catch (Exception ex)
        {
            await _auditLogService.LogActionAsync("DELETE", $"500 INTERNAL SERVER ERROR: Failed to delete transfer with id {transfer_id} - {ex.Message}", api_key);
            return new ServiceResult { StatusCode = 500, ErrorMessage = ex.Message };
        }
    }
}

public interface ITransferService
{
    Task<ServiceResult> ReadTransfers(string api_key);
    Task<ServiceResult> ReadTransfer(int trasnfer_id, string api_key);

    Task<ServiceResult> ReadTransferItems(int shipment_id, string api_key);
    Task<ServiceResult> CreateTransfer(Transfer transfer, string api_key);
    Task<ServiceResult> UpdateTransfer(Transfer transfer, int trasnfer_id, string api_key);
    Task<ServiceResult> DeleteTransfer(int trasnfer_id, string api_key);
}