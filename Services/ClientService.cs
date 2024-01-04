using System.Collections.Generic;
using System.Threading.Tasks;
using myClientListApp.Models;
using myClientListApp.Repositories;
using myClientListApp.Services;



public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> GetAllClients()
    {
        return await _clientRepository.GetAllClients();
    }

    public async Task<Client> GetClientById(int clientId)
    {
        return await _clientRepository.GetClientById(clientId);
    }

    public async Task<IEnumerable<Client>> SearchClients(string query)
    {
        return await _clientRepository.SearchClients(query);
    }


    public async Task AddClient(Client client)
    {
        await _clientRepository.AddClient(client);
    }

    public async Task UpdateClient(Client client)
    {
        await _clientRepository.UpdateClient(client);
    }

    public async Task DeleteClient(int clientId)
    {
        await _clientRepository.DeleteClient(clientId);
    }
}
