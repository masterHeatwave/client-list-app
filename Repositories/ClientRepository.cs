using Microsoft.EntityFrameworkCore;
using myClientListApp.Data;
using myClientListApp.Models;
using myClientListApp.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return await _dbContext.Clients.Include(c => c.PhoneNumbers).ToListAsync();
    }

    public async Task<Client> GetClientById(int clientId)
    {
        return await _dbContext.Clients.Include(c => c.PhoneNumbers).FirstOrDefaultAsync(c => c.Id == clientId)
        ?? throw new InvalidOperationException($"Client with ID {clientId} not found");
    }
    public async Task<IEnumerable<Client>> SearchClients(string query)
    {
        var clients = await GetAllClients(); 

        if (string.IsNullOrEmpty(query))
        {
            return clients; // Return all clients if the query is empty
        }

        // Perform a case-insensitive search by Name, Surname, or PhoneNumber
        return clients.Where(client =>
            client.Name?.ToLower().Contains(query.ToLower()) == true ||
            client.Surname?.ToLower().Contains(query.ToLower()) == true ||
            client.PhoneNumbers?.Any(phone => phone.Number.Contains(query)) == true
        );
    }

    public async Task AddClient(Client client)
    {
        _dbContext.Clients.Add(client);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateClient(Client client)
    {
        _dbContext.Entry(client).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteClient(int clientId)
    {
        var client = await _dbContext.Clients.FindAsync(clientId);
        if (client != null)
        {
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
