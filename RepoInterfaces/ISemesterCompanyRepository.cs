using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterCompanyRepository
    {
        public Task<IEnumerable<SemesterCompany>> GetSemesterCompany();
        public Task<IEnumerable<SemesterCompany>> GetSemesterCompanyBySemesterName(string semesterName);
        public Task<IEnumerable<SemesterCompany>> GetSemesterCompanyBySemesterId(int semesterId);
        public Task<IEnumerable<SemesterCompany>> GetSemesterCompanyByCompanyName(string companyName);
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
    }
}