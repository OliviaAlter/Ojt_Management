using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ICompanyJobRepository
    {
        public IQueryable<CompanyJob> GetCompanyJobList();
        public IQueryable<CompanyJob> GetCompanyJobById(int id);
        public Task<CompanyJob> AddCompanyJob(CompanyJob companyJob);
        public Task<CompanyJob> UpdateCompanyJob(int id, CompanyJob companyJob);
        public Task<bool> DeleteCompanyJob(int companyJobId);
    }
}