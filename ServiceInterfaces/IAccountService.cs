using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IAccountService
    {
        public Task<IEnumerable<Account>> GetAccountList();
        public Task<IEnumerable<Account>> GetAccountListByName(string name);
        public Task<Account> AddAccount(Account account);
        public Task<Account> UpdateAccount(Account account);
    }
}