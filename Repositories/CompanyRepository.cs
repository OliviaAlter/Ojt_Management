using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly OjtManagementContext _context;

        public CompanyRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanyList()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyByName(string companyName)
        {
            return await _context.Company.Where(c => c.CompanyName.Contains(companyName)).ToListAsync();
        }

        public async Task<Company> AddCompany(Company company)
        {
            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
            return company;        
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var found = await _context.Company.FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (found == null)
                return false;

            _context.Company.Remove(found);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Company> GetPagedListCompanyByName(string name)
        {
            return _context.Company.Where(c => c.CompanyName.Contains(name));
        }

        public IQueryable<Company> GetPagedListCompany()
        {
            return null;
        }
        
    }
}