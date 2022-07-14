using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterCompanyRepository
    {
        public Task<List<SemesterCompany>> GetSemesterCompany();
        public Task<List<SemesterCompany>> GetSemesterCompanyBySemesterName(string semesterName);
        public Task<List<SemesterCompany>> GetSemesterCompanyBySemesterId(int semesterId);
        public Task<List<SemesterCompany>> GetSemesterCompanyByCompanyName(string companyName);
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
    }
}