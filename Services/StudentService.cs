using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Student> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            return await _studentRepository.DeleteStudent(studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentList()
        {
            return await _studentRepository.GetStudentList()
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentListByName(string name)
        {
            return await _studentRepository.GetStudentListByName(name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentListAppliedByCompanyId(int companyId)
        {
            var studentList = await _studentRepository.GetStudentListAppliedByCompanyId(companyId)
                .ToListAsync();
            if (studentList == null || !studentList.Any())
                return null;
            
            return studentList;
        }

        public async Task<IEnumerable<Student>> GetStudentListByMajorId(int majorId)
        {
            var studentList = await _studentRepository.GetStudentListByMajorId(majorId)
                .ToListAsync();
            if (studentList == null || !studentList.Any()) 
                return null;

            return studentList;
        }

        public async Task<IEnumerable<Student>> GetStudentListBySemesterId(int semesterId)
        {
            var studentList = await _studentRepository.GetStudentListBySemesterId(semesterId)
                .ToListAsync();
            if (studentList == null || !studentList.Any()) 
                return null;

            return studentList;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            return await _studentRepository.UpdateStudent(student);
        }
    }
}