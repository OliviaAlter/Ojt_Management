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
    public class MajorRepository : IMajorRepository
    {
        private readonly OjtManagementContext _context;

        public MajorRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Major>> GetMajorList()
        {
            return await _context.Majors.ToListAsync();
        }

        public IQueryable<Major> GetMajorListByName(string majorName)
        {
            return _context.Majors.Where(u =>
                    string.Equals(u.MajorName, majorName, StringComparison.CurrentCultureIgnoreCase))
                .Include(s => s.MajorId);
        }

        public IQueryable<Major> GetMajorListBbyId(int majorId)
        {
            return _context.Majors
                .Where(u => u.MajorId == majorId);
        }

        public async Task<Major> AddMajor(Major major)
        {
            await _context.Majors.AddAsync(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<Major> UpdateMajor(Major major)
        { 
            _context.Majors.Update(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<bool> DeleteMajor(int majorId)
        {
            var majorExist = await _context.Majors
                .FirstOrDefaultAsync(s => s.MajorId == majorId);

            if (majorExist == null) 
                return false;
            
            _context.Majors.Remove(majorExist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}