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

    public async Task<Transfer> ReadTransfer(int transfer_id)
    {
        var transfer = await _context.Transfers.FindAsync(transfer_id);
        return transfer!;
    }

    public async Task<List<Transfer>> ReadTransfers()
    {
        return await _context.Transfers.ToListAsync();
    }

    public async Task<List<PropertyItem>> ReadTransferItems(int transfer_id)
    {
        var transfer = await _context.Transfers.FindAsync(transfer_id);
        if(transfer == null) return null;
        return transfer.Items;
    }

    public async Task<bool> CreateTransfer(Transfer transfer)
    {
        if (_context.Transfers.Any(x => x.Id == transfer.Id))
        {
            return false;
        }
        transfer.Created_At = DateTime.UtcNow;
        transfer.Updated_At = DateTime.UtcNow;
        _context.Transfers.Add(transfer);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateTransfer(Transfer transfer, int transfer_id)
    {
        var transfer_to_update = await _context.Transfers.FindAsync(transfer_id);
        if (transfer_to_update == null)
        {
            return false;
        }

        transfer_to_update.Reference = transfer.Reference;
        transfer_to_update.Transfer_From = transfer.Transfer_From;
        transfer_to_update.Transfer_To = transfer.Transfer_To;
        transfer_to_update.Transfer_Status = transfer.Transfer_Status;
        transfer_to_update.Items = transfer.Items;
        transfer_to_update.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteTransfer(int transfer_id)
    {
        var transfer = await _context.Transfers.FindAsync(transfer_id);
        if (transfer != null)
        {
            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    //public async Task<bool> CommitTransfer(int transfer_id)
    //{
    //    var transfer = await _context.Transfers.FindAsync(transfer_id);
    //    if (transfer == null) { return false; }
    //    foreach(var item in transfer.Items)
    //    {
    //        var Inventory = await _context.Inventories.FindAsync(x => x.Id == item["item_id"]);
    //        if (Inventory == null) { return false; }
    //        Inventory.Total_On_Hand += item["amount"]; 

    //    }

    //}
}

public interface ITransferService
{
    Task<List<Transfer>> ReadTransfers();
    Task<Transfer> ReadTransfer(int trasnfer_id);

    Task<List<PropertyItem>> ReadTransferItems(int shipment_id);
    Task<bool> CreateTransfer(Transfer transfer);
    Task<bool> UpdateTransfer(Transfer transfer, int trasnfer_id);
    Task<bool> DeleteTransfer(int trasnfer_id);
}