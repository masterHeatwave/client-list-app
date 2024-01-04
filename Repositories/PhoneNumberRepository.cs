using Microsoft.EntityFrameworkCore;
using myClientListApp.Data;
using myClientListApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace myClientListApp.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PhoneNumberRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PhoneNumber>> GetPhoneNumbersByClientId(int Id)
        {
            return await _dbContext.PhoneNumbers.Where(p => p.ClientId == Id).ToListAsync();
        }

        public async Task AddPhoneNumber(PhoneNumber phoneNumber)
        {
            _dbContext.PhoneNumbers.Add(phoneNumber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            _dbContext.Entry(phoneNumber).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePhoneNumber(int phoneNumberId)
        {
            var phoneNumber = await _dbContext.PhoneNumbers.FindAsync(phoneNumberId);
            if (phoneNumber != null)
            {
                _dbContext.PhoneNumbers.Remove(phoneNumber);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
