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
                            && a.Password == account.Password)
                .Include(b => b.Roles)
                .Include(c => c.Student);
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

        public async Task<bool> DeleteAccount(int accountId)
        {
            // find in company table
            var foundInCompany = await _context.Company
                .FirstOrDefaultAsync(x => x.AccountId == accountId);

            if (foundInCompany == null)
                return false;

            // find in Student table
            var foundInStudent = await _context.Student
                .FirstOrDefaultAsync(s => s.AccountId == accountId);

            if (foundInStudent == null)
                return false;

            // found in Account table
            var foundInAccount = await GetAccountById(accountId)
                .FirstOrDefaultAsync();

            if (foundInAccount == null)
                return false;

            // found if there are any ongoing application
            var foundInApplication = foundInStudent.JobApplications
                .Where(x => x.Student.AccountId == accountId);

            // if there is, delete them from the list
            if (!foundInApplication.Any())
            {
                var applicationByStudentId = _context.JobApplication
                    .Where(x => x.Student.AccountId == accountId);

                var list = await applicationByStudentId.ToListAsync();

                foreach (var applicationId in list)
                    _context.JobApplication
                        .Remove(applicationId);
            }

            try
            {
                _context.Company.Remove(foundInCompany);
                _context.Student.Remove(foundInStudent);
                _context.Account.Remove(foundInAccount);
            }
            catch
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private IQueryable<Account> GetAccountById(int accountId)
        {
            return _context.Account
                .Where(a => a.AccountId == accountId);
        }
    }
}