using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DatabaseContext dbContext)
    {
        if (!context.Request.Headers.TryGetValue("API_KEY", out var extractedApiKey))
        {
            context.Response.StatusCode = 401; 
            await context.Response.WriteAsync("API Key is missing");
            return;
        }

        var apiKeys = await dbContext.Api_Keys.ToListAsync();

        var apiKeyEntity = null as Api_Key; 

        foreach (var key in apiKeys)
        {
            if (BCrypt.Net.BCrypt.Verify(extractedApiKey, key.ApiKey))
            {
                apiKeyEntity = key; 
                break;
            }
        }

        if (apiKeyEntity == null)
        {
            context.Response.StatusCode = 403; 
            await context.Response.WriteAsync("Invalid API Key");
            return;
        }

        await _next(context);
    }

}
