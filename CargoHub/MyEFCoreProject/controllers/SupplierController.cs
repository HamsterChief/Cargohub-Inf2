using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("supplier")]
[ApiController]
public class SupplierController : Controller
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }
}