using System;
using System.Collections.Generic;
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
        
        public async Task<IEnumerable<Semester>> GetSemesters()
        {
            return await _context.Semester.ToListAsync();
        }

        public async Task<IEnumerable<Semester>> GetSemesterName(string semesterName)
        {
            return await _context.Semester
                .Where(s => string.Equals(s.SemesterName, semesterName, StringComparison.CurrentCultureIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Semester>> GetSemesterId(int semesterId)
        {
            return await _context.Semester
                .Where(s => s.SemesterId == semesterId).ToListAsync();
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
            var foundInSemester = await _context.Semester.FirstOrDefaultAsync(s => s.SemesterId == semesterId);

            if (foundInSemester == null)
                return false;

            _context.Semester.Remove(foundInSemester);
            
            //TODO: Check if there are any semester constrain
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}