using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class SupplierController : Controller
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }
  
    [HttpGet("suppliers/{id?}")]
    public async Task<IActionResult> Read(int? id)
    {
        if (id.HasValue){
            var result = await _supplierService.ReadSupplier(id.Value);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No supplier with Id: {id}");
        }
        else {
            var results = await _supplierService.GetAllSuppliers();
            return Ok(results);
        }
    }

    [HttpPost("suppliers")]
    public async Task<IActionResult> Create(Supplier supplier)
    {
        var result = await _supplierService.CreateSupplier(supplier);
        if (result)
        {
            return Ok("Supplier created successfully.");
        }
        return BadRequest("Failed to create supplier.");
    }

    [HttpPut("suppliers/{id}")]
    public async Task<IActionResult> Update(Supplier supplier, int id)
    {
        var result = await _supplierService.UpdateSupplier(supplier, id);
        if (result)
        {
            return Ok("Supplier updated successfully.");
        }
        return BadRequest("Failed to update supplier.");
    }

    [HttpDelete("suppliers/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _supplierService.DeleteSupplier(id);
        if (result)
        {
            return Ok("Supplier deleted successfully.");
        }
        return BadRequest("Failed to delete supplier.");
    }
}
