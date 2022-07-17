using System;
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

        public IQueryable<Company> GetCompanyList()
        {
            return _context.Company;
        }

        public IQueryable<Company> GetCompanyListByName(string companyName)
        {
            return _context.Company.Where(c => c.CompanyName.Contains(companyName));
        }

        public IQueryable<Company> GetCompanyById(int id)
        {
            return _context.Company.Where(c => c.CompanyId == id);
        }

        public IQueryable<Company> GetCompanyByName(string name)
        {
            return _context.Company.Where(c =>
                string.Equals(c.CompanyName, name,
                    StringComparison.CurrentCultureIgnoreCase));
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
    }
}