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

        public IQueryable<Major> GetMajorList()
        {
            return _context.Major;
        }

        public IQueryable<Major> GetMajorListByName(string majorName)
        {
            return _context.Major
                .Where(m => string.Equals(m.MajorName, majorName,
                    StringComparison.CurrentCultureIgnoreCase));
        }
        
        public IQueryable<Major> GetMajor(int majorId)
        {
            return _context.Major
                .Where(m => m.MajorId == majorId);
        }

        public async Task<Major> AddMajor(Major major)
        {
            await _context.Major.AddAsync(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<Major> UpdateMajor(Major major)
        {
            _context.Major.Update(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<bool> DeleteMajor(int majorId)
        {
            var foundInMajor = await _context.Major
                .FirstOrDefaultAsync(s => s.MajorId == majorId);

            if (foundInMajor == null)
                return false;
            //TODO : Check if there are no student bound with major that is about to be deleted
            _context.Major.Remove(foundInMajor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}