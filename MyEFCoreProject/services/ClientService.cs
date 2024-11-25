using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ClientService : IClientService
{
    private readonly DatabaseContext _context;

    public ClientService(DatabaseContext DbContext)
    {
        _context = DbContext;
    }

    public async Task<Client> ReadClient(int client_id)
    {
        var client = await _context.Clients.FindAsync(client_id);
        return client!;
    }

    public async Task<List<Client>> ReadClients()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<bool> CreateClient(Client client)
    {
        if (_context.Clients.Any(x => x.Id == client.Id))
        {
            return false;
        }
        client.Created_At = DateTime.UtcNow;
        client.Updated_At = DateTime.UtcNow;
        _context.Clients.Add(client);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateClient(Client client, int client_id)
    {
        var existingClient = await _context.Clients.FindAsync(client_id);
        if (existingClient == null)
        {
            return false;
        }

        existingClient.Name = client.Name;
        existingClient.Address = client.Address;
        existingClient.City = client.City;
        existingClient.Zip_Code = client.Zip_Code;
        existingClient.Province = client.Province;
        existingClient.Country = client.Country;
        existingClient.Contact_Name = client.Contact_Name;
        existingClient.Contact_Phone = client.Contact_Phone;
        existingClient.Contact_Email = client.Contact_Email;
        existingClient.Updated_At = DateTime.UtcNow;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> DeleteClient(int client_id)
    {
        var client = await _context.Clients.FindAsync(client_id);
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
    public Task<Client> ReadClient(int client_id);
    public Task<List<Client>> ReadClients();
    public Task<bool> CreateClient(Client client);
    public Task<bool> UpdateClient(Client client, int client_id);
    public Task<bool> DeleteClient(int client_id);
}
