using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("transfer")]
[ApiController]
public class TransferController : Controller
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }
}