using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
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
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            // find in Student table
            var foundInStudent = await _context.Student
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (foundInStudent == null)
                return false;

            // found in Account table
            var foundInAccount = await GetAccountByStudentId(studentId)
                .FirstOrDefaultAsync();

            if (foundInAccount == null)
                return false;

            // found if there are any ongoing application
            var foundInApplication = foundInStudent.JobApplications.Where(x => x.StudentId == studentId);

            // if there is, delete them from the list
            if (!foundInApplication.Any())
            {
                var applicationByStudentId = _context.JobApplication
                    .Where(x => x.StudentId == studentId);

                var list = await applicationByStudentId.ToListAsync();

                foreach (var applicationId in list) _context.JobApplication.Remove(applicationId);
            }

            try
            {
                _context.Student.Remove(foundInStudent);
                _context.Account.Remove(foundInAccount);
            }
            catch
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Student> GetStudentListAppliedByCompanyId(int companyId)
        {
            return _context.Student
                .Where(s => s.JobApplications
                    .Any(j => j.Company.CompanyId == companyId));
        }

        public IQueryable<Account> GetAccountByStudentId(int studentId)
        {
            return _context.Account
                .Where(a => a.AccountId == studentId);
        }

        public IQueryable<Student> GetStudentListByMajorId(int majorId)
        {
            return _context.Student
                .Where(s => s.MajorId == majorId);
        }

        public IQueryable<Student> GetStudentListBySemesterId(int semesterId)
        {
            return _context.Student
                .Where(s => s.Semester.SemesterId == semesterId);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public IQueryable<Student> GetStudentList()
        {
            return _context.Student;
        }

        public IQueryable<Student> GetStudentListByName(string name)
        {
            return _context.Student
                .Where(s => s.Account.Username.ToLower().Contains(name.ToLower()));
        }
    }
}