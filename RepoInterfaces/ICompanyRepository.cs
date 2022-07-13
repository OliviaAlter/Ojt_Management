using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ICompanyRepository
    {
        public Task<List<Company>> GetCompanyList();
        public Task<List<Company>> GetCompanyByName(string companyName);
        public Task<Company> AddCompany(Company company);
        public Task<Company> UpdateCompany(Company company);
        public Task<bool> DeleteCompany(int companyId);
        public IQueryable<Company> GetPagedListCompanyByName(string name);
        public IQueryable<Company> GetPagedListCompany();
    }
}