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
            var companyAdded = await _companyRepository.AddCompany(company);
            return companyAdded;
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var isDeleted = await _companyRepository.DeleteCompany(companyId);
            return isDeleted;
        }

        public async Task<List<Company>> GetCompanyList()
        {
            var companyList = await _companyRepository.GetCompanyList();
            return companyList;
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            var updated = await _companyRepository.UpdateCompany(company);
            return updated;
        }

        public async Task<List<Company>> GetCompanyByName(string name)
        {
            var companyList = await _companyRepository.GetCompanyByName(name);
            Console.WriteLine(companyList.Count);
            return companyList;
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