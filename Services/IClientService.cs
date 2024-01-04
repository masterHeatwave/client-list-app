using System.Collections.Generic;
using System.Threading.Tasks;
using myClientListApp.Models;
using myClientListApp.Services;

namespace myClientListApp.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<IEnumerable<Client>> SearchClients(string query);
        Task<Client> GetClientById(int clientId);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int clientId);
    }
}
