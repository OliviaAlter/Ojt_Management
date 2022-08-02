using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class CompanyJobRepository : ICompanyJobRepository
    {
        private readonly OjtManagementContext _context;

        public CompanyJobRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<CompanyJob> GetCompanyJobList()
        {
            return _context.CompanyJob;
        }

        public IQueryable<CompanyJob> GetCompanyJobById(int id)
        {
            return _context.CompanyJob
                .Where(x => x.CompanyJobId == id);
        }

        public async Task<CompanyJob> AddCompanyJob(CompanyJob companyJob)
        {
            await _context.CompanyJob.AddAsync(companyJob);
            await _context.SaveChangesAsync();
            return companyJob;        
        }

        public Task<CompanyJob> UpdateCompanyJob(int companyId, CompanyJob companyJob)
        {
            return null;
            // TODO : Feature :> 
        }

        public Task<bool> DeleteCompanyJob(int companyJobId)
        {
            return null;
            // TODO : Feature :> 
        }
    }
}