using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public static class ApiKeyService
{
    public static string GenerateApiKey()
    {
        return Guid.NewGuid().ToString(); 
    }

    public static string HashApiKey(string apiKey)
    {
        return BCrypt.Net.BCrypt.HashPassword(apiKey);
    }

    public static async Task<string> RequestGenerateAsync(int warehouse_id, DatabaseContext context)
    {
        await CreateAndSaveApiKeyAsync("dashboard", warehouse_id, context);
        await CreateAndSaveApiKeyAsync("scanner", warehouse_id, context);
        return "";
    }

    public static async Task<string> CreateAndSaveApiKeyAsync(string appName, int warehouse_id, DatabaseContext context)
    {
        var rawApiKey = GenerateApiKey();
        var encryptApiKey = HashApiKey(rawApiKey);

        var newApiKey = new Api_Key
        {
            ApiKey = encryptApiKey,
            Warehouse_Id = warehouse_id,
            App = appName
        };

        context.Api_Keys.Add(newApiKey);
        await context.SaveChangesAsync();

        Console.WriteLine($"Warehouse '{warehouse_id}' raw api key: {rawApiKey}");

        return $"{rawApiKey}, {warehouse_id}, {appName}";
    }

    public static async Task<List<string>> GenerateWarehouseApiKeys(string appName, DatabaseContext context)
    {
        var warehouses = await context.Warehouses.Select(warehouse => warehouse.Id).ToListAsync();
        var apikeys_raw = await Task.WhenAll(warehouses.Select(async warehouse_id => await CreateAndSaveApiKeyAsync(appName, warehouse_id, context)));
        return apikeys_raw.ToList();
    }

    public static async Task<bool> DeleteApiKey(int warehouse_id, DatabaseContext context)
    {
        var instance = await context.Api_Keys.FirstOrDefaultAsync(instance => instance.Warehouse_Id == warehouse_id);

        if (instance == null) { return false; }

        context.Api_Keys.Remove(instance);
        return await context.SaveChangesAsync() != 0;
    }
}