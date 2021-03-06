using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<Account>> GetAccountList();
        public Task<IEnumerable<Account>> GetAccountListContainName(string name);
        public Task<Account> AddAccount(Account account);
        public Task<Account> UpdateAccount(Account account);
        public Task<Account> GetAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
    }
}