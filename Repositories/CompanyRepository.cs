using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
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
            return null;
        }

        public Task<List<Company>> GetCompanyByName(string companyName)
        {
            return null;
        }

        public async Task<Company> AddCompany(Company company)
        {
            return company;

        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return company;        
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            
            return true;
        }

        public IQueryable<Company> GetPagedListCompanyByName(string name)
        {
            return null;
        }

        public IQueryable<Company> GetPagedListCompany()
        {
            return null;
        }
        
    }
}