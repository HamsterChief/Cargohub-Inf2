using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("api/v1")]
[ApiController]
public class SupplierController : Controller
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }
  
    [HttpGet("suppliers/{supplier_id}")]
    public async Task<IActionResult> ReadSupplier(int supplier_id)
    {
        var result = await _supplierService.ReadSupplier(supplier_id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"No such supplier with Id: {supplier_id}");
    }

    [HttpGet("suppliers")]
    public async Task<IActionResult> ReadSuppliers()
    {
        var result = await _supplierService.ReadSuppliers();
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound("No suppliers found");
    }

    [HttpGet("suppliers/{supplier_id}/items")]
    public async Task<IActionResult> ReadItemsForSuppliers(int supplier_id)
    {
        List<Item> result = await _supplierService.ReadItemsForSupplier(supplier_id);
        if (result.Count > 0)
        {
            return Ok(result);
        }
        return NotFound($"no items found for item_type with Id: {supplier_id}");
    }

    [HttpPost("suppliers")]
    public async Task<IActionResult> CreateSupplier(Supplier supplier)
    {
        var result = await _supplierService.CreateSupplier(supplier);
        if (result)
        {
            return Ok("Supplier created successfully.");
        }
        return BadRequest("Failed to create supplier.");
    }

    [HttpPut("suppliers/{supplier_id}")]
    public async Task<IActionResult> UpdateSupplier(Supplier supplier, int supplier_id)
    {
        var result = await _supplierService.UpdateSupplier(supplier, supplier_id);
        if (result)
        {
            return Ok("Supplier updated successfully.");
        }
        return BadRequest("Failed to update supplier.");
    }

    [HttpDelete("suppliers/{supplier_id}")]
    public async Task<IActionResult> DeleteSupplier(int supplier_id)
    {
        var result = await _supplierService.DeleteSupplier(supplier_id);
        if (result)
        {
            return Ok("Supplier deleted successfully.");
        }
        return BadRequest("Failed to delete supplier.");
    }
}