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

        public async Task<User> AddStudent(User student)
        {
            await _context.Users.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var studentFound = await _context.Users
                .FirstOrDefaultAsync(s => s.UserId == studentId && s.RoleId == (int)RoleEnum.Student);

            if (studentFound == null) 
                return false;
            
            _context.Users.Remove(studentFound);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<User> GetStudentList()
        {
            return _context.Users.Where(u => u.RoleId == (int)RoleEnum.Student);
        }

        public IQueryable<User> GetStudentListAppliedByCompanyId(int companyId)
        {
            return _context.Users.Where(u => u.RoleId == (int)RoleEnum.Student)
                .Include(s => s.UserCompanies)
                .Where(s => s.UserCompanies.Any(uc => uc.CompanyId == companyId));
        }

        public IQueryable<User> GetStudentListByMajorId(int majorId)
        {
            return _context.Users.Where(u => u.RoleId == (int)RoleEnum.Student)
                .Include(s => s.Major)
                .Where(s => s.MajorId == majorId);
        }

        public IQueryable<User> GetStudentListBySemesterId(int semesterId)
        {
            return _context.Users.Where(u => u.RoleId == (int)RoleEnum.Student)
                .Include(s => s.UserSemesters)
                .Where(s => s.UserSemesters.Any(uc => uc.SemesterId == semesterId));
        }

        public async Task<User> UpdateStudent(User student)
        {
            _context.Users.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}