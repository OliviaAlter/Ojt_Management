using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddCompany(Company company)
        {
            return await _companyRepository.AddCompany(company);
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            return await _companyRepository.DeleteCompany(companyId);
        }

        public async Task<Company> UpdateCompany(int id, Company company)
        {
            return await _companyRepository.UpdateCompany(id, company);
        }

        public async Task<IEnumerable<Company>> GetCompanyList()
        {
            return await _companyRepository.GetCompanyList()
                .ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyListByName(string name)
        {
            return await _companyRepository.GetCompanyListByName(name)
                .ToListAsync();
        }

        public async Task<Company> GetCompanyByName(string name)
        {
            return await _companyRepository.GetCompanyByName(name)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _companyRepository.GetCompanyById(id)
                .FirstOrDefaultAsync();
        }
    }
}