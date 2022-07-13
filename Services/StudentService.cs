using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OJTManagementAPI.CustomEntities;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Options;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly PaginationOptions _paginationOptions;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IOptions<PaginationOptions> options)
        {
            _studentRepository = studentRepository;
            _paginationOptions = options.Value;
        }

        public async Task<User> AddStudent(User student)
        {
            var newStudent = await _studentRepository.AddStudent(student);
            return newStudent;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var isDeleted = await _studentRepository.DeleteStudent(studentId);
            return isDeleted;
        }

        public async Task<PagedList<User>> GetStudentList(int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentList();
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<User>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<PagedList<User>> GetStudentListAppliedByCompanyId(int companyId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListAppliedByCompanyId(companyId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<User>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<PagedList<User>> GetStudentListByMajorId(int majorId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListByMajorId(majorId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<User>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<PagedList<User>> GetStudentListBySemesterId(int semesterId, int? page, int? pageSize)
        {
            var studentList = _studentRepository.GetStudentListBySemesterId(semesterId);
            if (studentList == null || !studentList.Any()) return null;
            var pageNum = page ?? _paginationOptions.DefaultPageNumber;
            var size = pageSize ?? _paginationOptions.DefaultPageSize;

            var pagedList = await PagedList<User>.Create(studentList, pageNum, size);

            return pagedList;
        }

        public async Task<User> UpdateStudent(User student)
        {
            var updatedStudent = await _studentRepository.UpdateStudent(student);
            return updatedStudent;
        }
    }
}