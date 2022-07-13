using System;
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

        public async Task<List<Company>> GetCompanyList()
        {
            return await _context.Companies.ToListAsync();
        }

        public Task<List<Company>> GetCompanyByName(string companyName)
        {
            return _context.Companies.Where(c => c.CompanyName.Contains(companyName)).ToListAsync();
        }

        public async Task<Company> AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return company;

        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;        
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var companyFound = await _context.Companies
                .FirstOrDefaultAsync(s => s.CompanyId == companyId);

            if (companyFound == null) 
                return false;
            
            _context.Companies.Remove(companyFound);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Company> GetPagedListCompanyByName(string name)
        {
            return _context.Companies.Where(c => c.CompanyName.Contains(name));
        }

        public IQueryable<Company> GetPagedListCompany()
        {
            return _context.Companies;
        }
        
    }
}