using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ClientService : IClientService
{
    private readonly DatabaseContext _context;

    public ClientService(DatabaseContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Client> ReadClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        return client!;
    }

    public async Task<bool> CreateClient(Client client)
    {
        client.created_at = DateTime.UtcNow;
        client.updated_at = DateTime.UtcNow;
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateClient(Client client, int id)
    {
        var existingClient = await _context.Clients.FindAsync(id);
        if (existingClient == null)
        {
            return false;
        }

        existingClient.name = client.name;
        existingClient.address = client.address;
        existingClient.city = client.city;
        existingClient.zip_code = client.zip_code;
        existingClient.province = client.province;
        existingClient.country = client.country;
        existingClient.contact_name = client.contact_name;
        existingClient.contact_phone = client.contact_phone;
        existingClient.contact_email = client.contact_email;
        existingClient.updated_at = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return false;
        }
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IClientService
{
    public Task<Client> ReadClient(int id);
    public Task<bool> CreateClient(Client client);
    public Task<bool> UpdateClient(Client client, int id);
    public Task<bool> DeleteClient(int id);
}
