using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OjtManagementContext _context;

        public AccountRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAccountList()
        {
            return _context.Account;
        }

        public IQueryable<Account> GetAccountByName(string name)
        {
            return _context.Account.Where(a => string.Equals(a.Username, name,
                StringComparison.CurrentCultureIgnoreCase));
        }

        public IQueryable<Account> GetAccountById(int id)
        {
            return _context.Account.Where(a => a.AccountId == id);
        }

        public IQueryable<Account> GetAccountListContainName(string name)
        {
            return _context.Account.Where(a => a.Username.ToLower().Contains(name.ToLower()));
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