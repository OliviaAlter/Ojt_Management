using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.Enums;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly OjtManagementContext _context;

        public StudentRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            return null;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            return true;
        }

        public IQueryable<Student> GetStudentList()
        {
            return null;
        }

        public IQueryable<Student> GetStudentListAppliedByCompanyId(int companyId)
        {
            return null;
        }

        public IQueryable<Student> GetStudentListByMajorId(int majorId)
        {
            return null;
        }

        public IQueryable<Student> GetStudentListBySemesterId(int semesterId)
        {
            return null;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            return student;
        }
    }
}