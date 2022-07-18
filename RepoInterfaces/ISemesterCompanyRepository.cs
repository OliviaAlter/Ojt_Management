using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterCompanyRepository
    {
        public IQueryable<SemesterCompany> GetSemesterCompanyList();
        public IQueryable<SemesterCompany> GetSemesterCompanyListBySemesterName(string semesterName);
        public IQueryable<SemesterCompany> GetSemesterCompanyBySemesterId(int semesterId);
        public IQueryable<SemesterCompany> GetSemesterCompanyListByCompanyName(string companyName);
        public IQueryable<SemesterCompany> GetSemesterCompanyByCompanyId(int companyId);
        public IQueryable<SemesterCompany> GetSemesterCompanyBySemesterCompanyId(int semesterCompanyId);
        public IQueryable<SemesterCompany> GetSemesterCompanyByName(string semesterCompanyName);
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(int id, SemesterCompanyDTO semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
    }
}