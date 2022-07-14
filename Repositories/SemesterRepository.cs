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
        
        public async Task<List<Semester>> GetSemesters()
        {
            return await _context.Semester.ToListAsync();
        }

        public async Task<List<Semester>> GetSemesterName(string semesterName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Semester>> GetSemesterId(int semesterId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Semester> AddSemester(Semester semester)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Semester> UpdateSemester(Semester semester)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteSemester(int semesterId)
        {
            throw new System.NotImplementedException();
        }
    }
}