using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IStudentService
    {
        //public Task<PagedList<Student>> GetStudentList(int? page, int? pageSize);
        public Task<IEnumerable<Student>> GetStudentList();
        public Task<IEnumerable<Student>> GetStudentListByName(string name);
        public Task<PagedList<Student>> GetStudentListBySemesterId(int semesterId, int? page, int? pageSize);
        public Task<PagedList<Student>> GetStudentListByMajorId(int majorId, int? page, int? pageSize);
        public Task<PagedList<Student>> GetStudentListAppliedByCompanyId(int companyId, int? page, int? pageSize);
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(int studentId);
    }
}