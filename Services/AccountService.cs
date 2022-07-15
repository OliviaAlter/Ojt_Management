using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAccountList()
        {
            return await _accountRepository.GetAccountList();
        }

        public async Task<IEnumerable<Account>> GetAccountListByName(string name)
        {
            return await _accountRepository.GetAccountContainName(name);
        }

        public async Task<Account> AddAccount(Account account)
        {
            return await _accountRepository.AddAccount(account);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await _accountRepository.UpdateAccount(account);
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            return await _accountRepository.DeleteAccount(accountId);
        }
    }
}