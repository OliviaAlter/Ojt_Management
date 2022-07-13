using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetStudentList();
        public IQueryable<Student> GetStudentListBySemesterId(int semesterId);
        public IQueryable<Student> GetStudentListByMajorId(int majorId);
        public IQueryable<Student> GetStudentListAppliedByCompanyId(int companyId);
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(int studentId);
    }
}