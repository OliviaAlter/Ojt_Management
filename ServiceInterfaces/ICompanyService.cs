using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ICompanyService
    {
        public Task<Company> AddCompany(Company company);
        // TODO : Delete company 
        public Task<bool> DeleteCompany(int companyId);
        public Task<Company> UpdateCompany(int id, Company company);
        public Task<IEnumerable<Company>> GetCompanyList();
        public Task<IEnumerable<Company>> GetCompanyListByName(string name);
        public Task<Company> GetCompanyByName(string name);
        public Task<Company> GetCompanyById(int id);
    }
}