using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Options;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly PaginationOptions _paginationOptions;

        public CompanyService(ICompanyRepository companyRepository, IOptions<PaginationOptions> options)
        {
            _companyRepository = companyRepository;
            _paginationOptions = options.Value;
        }

        public async Task<Company> AddCompany(Company company)
        {
            return await _companyRepository.AddCompany(company);
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            return await _companyRepository.DeleteCompany(companyId);
        }

        public async Task<List<Company>> GetCompanyList()
        {
            return await _companyRepository.GetCompanyList();
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            return await _companyRepository.UpdateCompany(company);
        }

        public async Task<List<Company>> GetCompanyByName(string name)
        {
            return await _companyRepository.GetCompanyByName(name);
        }

        public async Task<PagedList<Company>> GetPagedListCompany(int? page, int? pageSize)
        {
            var companyList = _companyRepository.GetPagedListCompany();
            if (companyList == null || !companyList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<Company>.Create(companyList, pageNum, size);

            return pagedList;
        }

        public Task<PagedList<Company>> GetPagedListCompanyByName(string name, int? page, int? pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}