using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class AccountRepository :IAccountRepository
    {
        private readonly OjtManagementContext _context;

        public AccountRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccountList()
        {
            return await _context.Account.ToListAsync();
        }

        public IQueryable<Account> GetAccountByName(string name)
        {
            return _context.Account.Where(a => a.Username == name);
        }

        public async Task<IEnumerable<Account>> GetAccountContainName(string name)
        {
            return await _context.Account.Where(a => a.Username == name)
                .ToListAsync();
        }
        
        public async Task<Account> AddAccount(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            var foundInAccount = await _context.Account
                .FirstOrDefaultAsync(s => s.AccountId == accountId);

            if (foundInAccount == null)
                return false;
            //TODO : Check if there are no on-going ojt bound with this account that is about to be deleted
            _context.Account.Remove(foundInAccount);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}