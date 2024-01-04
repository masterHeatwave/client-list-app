using myClientListApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myClientListApp.Repositories
{

    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<IEnumerable<Client>> SearchClients(string query);
        Task<Client> GetClientById(int clientId);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int clientId);
    }
}


