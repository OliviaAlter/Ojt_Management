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

        public IQueryable<Account> GetAccount(Account account)
        {
            return _context.Account
                .Where(a => a.Email == account.Email
                            && a.Password == account.Password);
        }
        
        public IQueryable<Account> GetAccountListContainName(string name)
        {
            return _context.Account
                .Where(a => a.Username.ToLower().Contains(name.ToLower()));
        }

        public async Task<Account> AddAccount(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}