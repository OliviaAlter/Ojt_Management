using System.Linq;
using System.Threading.Tasks;
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
        public IQueryable<SemesterCompany> GetSemesterCompanyById(int semesterCompanyId);
        public IQueryable<SemesterCompany> GetSemesterCompanyByName(string semesterCompanyName);
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
    }
}