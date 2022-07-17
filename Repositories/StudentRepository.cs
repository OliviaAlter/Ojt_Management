using System;
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

        public IQueryable<JobApplication> GetJobApplicationByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var foundInStudent = await _context.Student
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            if (foundInStudent == null)
                return false;
                
            var accountId = foundInStudent.Account.AccountId;

            var foundInAccount = await _context.Account
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (foundInAccount == null)
                return false;
            
            var foundInApplication = foundInStudent.JobApplications.
                Any(x => x.StudentId == studentId);

            if (foundInApplication)
            {
                var applicationByStudentId = _context.JobApplication
                    .Where(x => x.StudentId == studentId);

                var list = await applicationByStudentId.ToListAsync();
                
                foreach (var applicationId in list)
                {
                    _context.JobApplication.Remove(applicationId);
                }
            }
            
            try
            {
                _context.Student.Remove(foundInStudent);
                _context.Account.Remove(foundInAccount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            

            //TODO: Check if there are any ongoing OJT for the student

            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Student> GetStudentListAppliedByCompanyId(int companyId)
        {
            return _context.Student
                .Where(s => s.JobApplications
                    .Any(j => j.Company.CompanyId == companyId));
        }

        public IQueryable<Student> GetStudentInAccountByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAccountByStudentId(int studentId)
        {
            throw new NotImplementedException();
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