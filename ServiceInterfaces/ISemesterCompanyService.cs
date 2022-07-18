using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ISemesterCompanyService
    {
        public Task<IEnumerable<SemesterCompany>> GetSemesterCompanyList();
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(int id, SemesterCompanyDTO semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
        public Task<SemesterCompany> GetSemesterCompanyById(int id);
        public Task<SemesterCompany> GetSemesterCompanyByCompanyName(string semesterCompanyName);
        public Task<SemesterCompany> GetSemesterCompanyByCompanyId(int semesterCompanyId);
        public Task<List<SemesterCompany>> GetSemesterCompanyListBySemesterId(int semesterId);
        public Task<List<SemesterCompany>> GetSemesterCompanyListBySemesterName(string semesterName);
        public Task<List<SemesterCompany>> GetSemesterCompanyListByName(string semesterCompanyName);
    }
}