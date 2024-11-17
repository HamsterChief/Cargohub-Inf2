using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TransferService : ITransferService
{
    private DatabaseContext _context;

    public TransferService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }
}

public interface ITransferService
{
    
}
