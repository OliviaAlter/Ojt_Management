using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class SemesterCompanyService : ISemesterCompanyService
    {
        private readonly ISemesterCompanyRepository _semesterCompanyRepository;

        public SemesterCompanyService(ISemesterCompanyRepository semesterCompanyRepository)
        {
            _semesterCompanyRepository = semesterCompanyRepository;
        }

        public async Task<IEnumerable<SemesterCompany>> GetSemesterCompanyList()
        {
            return await _semesterCompanyRepository.GetSemesterCompanyList()
                .ToListAsync();
        }

        public async Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany)
        {
            return await _semesterCompanyRepository.AddSemesterCompany(semesterCompany);
        }

        public async Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany)
        {
            return await _semesterCompanyRepository.UpdateSemesterCompany(semesterCompany);
        }

        public async Task<bool> DeleteSemesterCompany(int semesterCompanyId)
        {
            return await _semesterCompanyRepository.DeleteSemesterCompany(semesterCompanyId);
        }

        public async Task<SemesterCompany> GetSemesterCompanyById(int semesterCompanyId)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyById(semesterCompanyId)
                .FirstOrDefaultAsync();
        }

        public async Task<SemesterCompany> GetSemesterCompanyByCompanyId(int semesterCompanyId)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyByCompanyId(semesterCompanyId)
                .FirstOrDefaultAsync();
        }

        public async Task<SemesterCompany> GetSemesterCompanyByCompanyName(string semesterCompanyName)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyByName(semesterCompanyName)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyListBySemesterId(int semesterId)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyBySemesterId(semesterId)
                .ToListAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyListBySemesterName(string semesterName)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyListBySemesterName(semesterName)
                .ToListAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyListByName(string semesterCompanyName)
        {
            return await _semesterCompanyRepository.GetSemesterCompanyListByCompanyName(semesterCompanyName)
                .ToListAsync();
        }
    }
}