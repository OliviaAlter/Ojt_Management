using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ICompanyRepository
    {
        public IQueryable<Company> GetCompanyList();
        public IQueryable<Company> GetCompanyListByName(string companyName);
        public IQueryable<Company> GetCompanyById(int id);
        public IQueryable<Company> GetCompanyByName(string name);
        public Task<Company> AddCompany(Company company);
        public Task<Company> UpdateCompany(Company company);
        public Task<bool> DeleteCompany(int companyId);
    }
}