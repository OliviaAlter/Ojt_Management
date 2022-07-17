using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly OjtManagementContext _context;

        public SemesterRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<Semester> GetSemesterList()
        {
            return _context.Semester;
        }

        public IQueryable<Semester> GetSemesterName(string semesterName)
        {
            return _context.Semester
                .Where(s => s.SemesterName.ToLower().Contains(semesterName.ToLower()));
        }

        public IQueryable<Semester> GetSemesterById(int semesterId)
        {
            return _context.Semester
                .Where(s => s.SemesterId == semesterId);
        }

        public async Task<Semester> AddSemester(Semester semester)
        {
            await _context.Semester.AddAsync(semester);
            await _context.SaveChangesAsync();
            return semester;
        }

        public async Task<Semester> UpdateSemester(Semester semester)
        {
            _context.Semester.Update(semester);
            await _context.SaveChangesAsync();
            return semester;
        }

        public async Task<bool> DeleteSemester(int semesterId)
        {
            var foundInSemester = await _context.Semester
                .FirstOrDefaultAsync(s => s.SemesterId == semesterId);

            if (foundInSemester == null)
                return false;

            _context.Semester.Remove(foundInSemester);

            //TODO: Check if there are any semester constrain

            await _context.SaveChangesAsync();
            return true;
        }
    }
}