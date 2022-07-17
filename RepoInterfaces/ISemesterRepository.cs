using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterRepository
    {
        public IQueryable<Semester> GetSemesterList();
        public IQueryable<Semester> GetSemesterName(string semesterName);
        public IQueryable<Semester> GetSemesterById(int semesterId);
        public Task<Semester> AddSemester(Semester semesterCompany);
        public Task<Semester> UpdateSemester(Semester semesterCompany);
        public Task<bool> DeleteSemester(int semesterCompanyId);
    }
}