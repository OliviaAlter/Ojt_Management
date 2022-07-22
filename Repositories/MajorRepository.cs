using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.DTOS;
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
                .Where(m => m.MajorName.Contains(majorName));
        }

        public IQueryable<Major> GetMajorById(int majorId)
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
            try
            {
                var majorData = await _context.Major
                    .FirstOrDefaultAsync(x => x.MajorId == major.MajorId);
                //var majorData = _context.Major.Update(major);
                if (majorData != null)
                {
                    majorData.MajorName ??= major.MajorName;
                    await _context.SaveChangesAsync();

                    var studentListWithSameMajorId = await _context.Student
                        .Where(x => x.Major.MajorId == major.MajorId).ToListAsync();

                    foreach (var student in studentListWithSameMajorId) student.Major.MajorName = major.MajorName;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return null;
            }

            return major;
        }

        public async Task<Major> UpdateMajorById(int majorId, MajorUpdateDTO major)
        {
            var majorData = await _context.Major
                .FirstOrDefaultAsync(x => x.MajorId == majorId);
            try
            {
                if (majorData != null)
                {
                    majorData.MajorName = major.MajorName;

                    await _context.SaveChangesAsync();

                    var studentListWithSameMajorId = await _context.Student
                        .Where(x => x.Major.MajorId == major.MajorId).ToListAsync();

                    foreach (var student in studentListWithSameMajorId) student.Major.MajorName = major.MajorName;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return null;
            }

            return majorData;
        }

        public async Task<bool> DeleteMajor(int majorId)
        {
            try
            {
                var foundInMajor = await _context.Major
                    .FirstOrDefaultAsync(s => s.MajorId == majorId);

                if (foundInMajor == null)
                    return false;

                var foundInStudent = await _context.Student
                    .Where(s => s.MajorId == majorId)
                    .ToListAsync();

                if (foundInStudent.Count > 0 || !foundInStudent.Any()) return false;

                //TODO : Check if there are no student bound with major that is about to be deleted
                _context.Major.Remove(foundInMajor);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }
        }
    }
}