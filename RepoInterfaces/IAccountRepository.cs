using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IAccountRepository
    {
        public IQueryable<Account> GetAccountList();
        public IQueryable<Account> GetAccountByName(string name);
        public IQueryable<Account> GetAccountListContainName(string name);
        public IQueryable<Account> GetAccount(Account account);
        public Task<Account> AddAccount(Account account);
        public Task<Account> UpdateAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
    }
}