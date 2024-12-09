using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DatabaseContext dbContext)
    {
        if (!context.Request.Headers.TryGetValue("API_KEY", out var apiKeyValues))
        {
            context.Response.StatusCode = 401; 
            await context.Response.WriteAsync("API Key is missing.");
            return;
        }

        var extractedApiKey = apiKeyValues.ToString();


        var apiKeys = await dbContext.Api_Keys.ToListAsync();

        var apiKeyEntity = apiKeys.FirstOrDefault(key => 
            BCrypt.Net.BCrypt.Verify(extractedApiKey, key.ApiKey)
        );

        if (apiKeyEntity == null)
        {
            context.Response.StatusCode = 403; 
            await context.Response.WriteAsync("Invalid API Key.");
            return;
        }

        await _next(context);
    }
}
