using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IStudentRepository
    {
        public IQueryable<User> GetStudentList();
        public IQueryable<User> GetStudentListBySemesterId(int semesterId);
        public IQueryable<User> GetStudentListByMajorId(int majorId);
        public IQueryable<User> GetStudentListAppliedByCompanyId(int companyId);
        public Task<User> AddStudent(User student);
        public Task<User> UpdateStudent(User student);
        public Task<bool> DeleteStudent(int studentId);
    }
}