using myClientListApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myClientListApp.Repositories
{
    public interface IPhoneNumberRepository
    {
        Task<IEnumerable<PhoneNumber>> GetPhoneNumbersByClientId(int clientId);
        Task AddPhoneNumber(PhoneNumber phoneNumber);
        Task UpdatePhoneNumber(PhoneNumber phoneNumber);
        Task DeletePhoneNumber(int phoneNumberId);
    }
}
