using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ICompanyService
    {
        public Task<Company> AddCompany(Company company);
        public Task<bool> DeleteCompany(int companyId);
        public Task<List<Company>> GetCompanyList();
        public Task<Company> UpdateCompany(Company company);
        public Task<List<Company>> GetCompanyByName(string name);
        public Task<PagedList<Company>> GetPagedListCompany(int? page, int? pageSize);
        public Task<PagedList<Company>> GetPagedListCompanyByName(string name, int? page, int? pageSize);
    }
}