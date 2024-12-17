using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ApiKeyMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context, DatabaseContext dbContext)
    {
        if (!context.Request.Headers.TryGetValue("API_KEY", out var extractedApiKey))
        {
            context.Response.StatusCode = 401; 
            await context.Response.WriteAsync("API Key is missing");
            await LogAuditAsync(context.Request.Method, "401 UNAUTHORIZED: Missing API Key", extractedApiKey);
            return;
        }

        var apiKeys = await dbContext.Api_Keys.ToListAsync();
        var apiKeyEntity = apiKeys.FirstOrDefault(key => BCrypt.Net.BCrypt.Verify(extractedApiKey, key.ApiKey));

        if (apiKeyEntity == null)
        {
            context.Response.StatusCode = 403; 
            await context.Response.WriteAsync("Invalid API Key");
            await LogAuditAsync(context.Request.Method, "403 FORBIDDEN: Invalid API Key", extractedApiKey);
            return;
        }

        await LogAuditAsync(context.Request.Method, "200 OK: Valid API Key used", extractedApiKey);
        await _next(context);
    }

    private async Task LogAuditAsync(string method, string message, string apiKey)
    {
        try
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var auditLogService = scope.ServiceProvider.GetRequiredService<IAuditLogService>();
                await auditLogService.LogAPIKeyAsync(method, message, apiKey);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audit log failed: {ex.Message}");
        }
    }
}
