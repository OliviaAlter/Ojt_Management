using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IAccountService
    {
        public Task<List<Account>> GetAccountList();
        public Task<List<Account>> GetAccountListByName(string name);
        public Task<Account> AddAccount(Account account);
        public Task<Account> UpdateAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
    }
}