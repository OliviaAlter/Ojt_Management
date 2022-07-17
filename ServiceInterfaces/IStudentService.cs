using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IStudentService
    {
        //public Task<PagedList<Student>> GetStudentList(int? page, int? pageSize);
        public Task<IEnumerable<Student>> GetStudentList();
        public Task<IEnumerable<Student>> GetStudentListByName(string name);
        public Task<IEnumerable<Student>> GetStudentListBySemesterId(int semesterId);
        public Task<IEnumerable<Student>> GetStudentListByMajorId(int majorId);
        public Task<IEnumerable<Student>> GetStudentListAppliedByCompanyId(int companyId);
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(int studentId);
    }
}