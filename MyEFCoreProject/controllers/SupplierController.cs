using Microsoft.AspNetCore.Mvc;

namespace MyEFCoreProject.Controllers;

[Route("cargohub")]
[ApiController]
public class SupplierController : Controller
{
    private readonly ISupplierService _supplierService;
    private readonly IAuditLogService _auditLogService;

    public SupplierController(ISupplierService supplierService, IAuditLogService auditLogService)
    {
        _supplierService = supplierService;
        _auditLogService = auditLogService;
    }
  
    [HttpGet("suppliers/{supplier_id}")]
    public async Task<IActionResult> ReadSupplier(int supplier_id)
    {
        var result = await _supplierService.ReadSupplier(supplier_id);
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching supplier", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching supplier", Request.Headers["API_KEY"]!);
        return NotFound($"No such supplier with Id: {supplier_id}");
    }

    [HttpGet("suppliers")]
    public async Task<IActionResult> ReadSuppliers()
    {
        var result = await _supplierService.ReadSuppliers();
        if (result != null)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching multiple suppliers", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching multiple suppliers", Request.Headers["API_KEY"]!);
        return NotFound("No suppliers found");
    }

    [HttpGet("suppliers/{supplier_id}/items")]
    public async Task<IActionResult> ReadItemsForSuppliers(int supplier_id)
    {
        List<Item> result = await _supplierService.ReadItemsForSupplier(supplier_id);
        if (result.Count > 0)
        {
            await _auditLogService.LogActionAsync("GET", "200 OK: Fetching items for supplier", Request.Headers["API_KEY"]!);
            return Ok(result);
        }
        await _auditLogService.LogActionAsync("GET", "404 NOT FOUND: Fetching items for supplier", Request.Headers["API_KEY"]!);
        return NotFound($"no items found for item_type with Id: {supplier_id}");
    }

    [HttpPost("suppliers")]
    public async Task<IActionResult> CreateSupplier(Supplier supplier)
    {
        var result = await _supplierService.CreateSupplier(supplier);
        if (result)
        {
            await _auditLogService.LogActionAsync("POST", "200 OK: Creating supplier", Request.Headers["API_KEY"]!);
            return Ok("Supplier created successfully.");
        }
        await _auditLogService.LogActionAsync("POST", "400 BAD REQUEST: Creating supplier", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to create supplier.");
    }

    [HttpPut("suppliers/{supplier_id}")]
    public async Task<IActionResult> UpdateSupplier(Supplier supplier, int supplier_id)
    {
        var result = await _supplierService.UpdateSupplier(supplier, supplier_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("PUT", "200 OK: Updating supplier", Request.Headers["API_KEY"]!);
            return Ok("Supplier updated successfully.");
        }
        await _auditLogService.LogActionAsync("PUT", "400 BAD REQUEST: Updating supplier", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to update supplier.");
    }

    [HttpDelete("suppliers/{supplier_id}")]
    public async Task<IActionResult> DeleteSupplier(int supplier_id)
    {
        var result = await _supplierService.DeleteSupplier(supplier_id);
        if (result)
        {
            await _auditLogService.LogActionAsync("DELETE", "200 OK: Deleting supplier", Request.Headers["API_KEY"]!);
            return Ok("Supplier deleted successfully.");
        }
        await _auditLogService.LogActionAsync("DELETE", "400 BAD REQUEST: Deleting supplier", Request.Headers["API_KEY"]!);
        return BadRequest("Failed to delete supplier.");
    }
}