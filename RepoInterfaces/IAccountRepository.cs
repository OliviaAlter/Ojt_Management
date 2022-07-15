using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IAccountRepository
    {
        public Task<IEnumerable<Account>> GetAccountList();
        public IQueryable<Account> GetAccountByName(string name);
        public Task<IEnumerable<Account>> GetAccountContainName(string name);
        public Task<Account> AddAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
        public Task<Account> UpdateAccount(Account account);
    }
}