using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class TransferService : ITransferService
{
    private readonly DatabaseContext _context;

    public TransferService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Transfer> ReadTransfer(int id)
    {
        var transfer = await _context.Transfers.FindAsync(id);
        if (transfer != null)
        {
            return transfer;
        }
        return null;
    }

    public async Task<IEnumerable<Transfer>> GetAllTransfers(int page)
    {
        const int defaultPageSize = 500; 

        return await _context.Transfers
                            .AsNoTracking()
                            .Skip((page - 1) * defaultPageSize) 
                            .Take(defaultPageSize) 
                            .ToListAsync();
    }


    public async Task<bool> CreateTransfer(Transfer transfer)
    {
        transfer.created_at = DateTime.UtcNow;
        transfer.updated_at = DateTime.UtcNow;
        _context.Transfers.Add(transfer);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateTransfer(Transfer transfer, int id)
    {
        var transfer_to_update = await _context.Transfers.FindAsync(id);
        if (transfer_to_update == null)
        {
            return false;
        }

        transfer_to_update.reference = transfer.reference;
        transfer_to_update.transfer_from = transfer.transfer_from;
        transfer_to_update.transfer_to = transfer.transfer_to;
        transfer_to_update.transfer_status = transfer.transfer_status;
        transfer_to_update.items = transfer.items;
        transfer_to_update.updated_at = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteTransfer(int id)
    {
        var transfer = await _context.Transfers.FindAsync(id);
        if (transfer != null)
        {
            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}

public interface ITransferService
{
    Task<Transfer> ReadTransfer(int id);

    Task<IEnumerable<Transfer>> GetAllTransfers(int page);
    Task<bool> CreateTransfer(Transfer transfer);
    Task<bool> UpdateTransfer(Transfer transfer, int id);
    Task<bool> DeleteTransfer(int id);
}
