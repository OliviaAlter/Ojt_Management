using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAccountList();
        public IQueryable<Account> GetAccountByName(string name);
        public Task<List<Account>> GetAccountContainName(string name);
        public Task<Account> AddAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
        public Task<Account> UpdateAccount(Account account);
    }
}