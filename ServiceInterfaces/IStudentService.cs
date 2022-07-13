using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IStudentService
    {
        public Task<PagedList<User>> GetStudentList(int? page, int? pageSize);
        public Task<PagedList<User>> GetStudentListBySemesterId(int semesterId, int? page, int? pageSize);
        public Task<PagedList<User>> GetStudentListByMajorId(int majorId, int? page, int? pageSize);
        public Task<PagedList<User>> GetStudentListAppliedByCompanyId(int companyId, int? page, int? pageSize);
        public Task<User> AddStudent(User student);
        public Task<User> UpdateStudent(User student);
        public Task<bool> DeleteStudent(int studentId);
    }
}