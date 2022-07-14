using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.Repositories
{
    public class SemesterCompanyRepository
    {
        private readonly OjtManagementContext _context;

        public SemesterCompanyRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public async Task<List<SemesterCompany>> GetSemesterCompany()
        {
            return await _context.SemesterCompany.ToListAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyBySemesterName(string semesterName)
        {
            return await _context.SemesterCompany
                .Where(x => x.Semester.SemesterName == semesterName).ToListAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyBySemesterId(int semesterId)
        {
            return await _context.SemesterCompany
                .Where(x => x.Semester.SemesterId == semesterId).ToListAsync();
        }

        public async Task<List<SemesterCompany>> GetSemesterCompanyByCompanyName(string companyName)
        {
            return await _context.SemesterCompany
                .Where(x => x.Company.CompanyName.Contains(companyName)).ToListAsync();
        }

        public async Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany)
        {
            await _context.SemesterCompany.AddAsync(semesterCompany);
            await _context.SaveChangesAsync();
            return semesterCompany;
        }

        public async Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany)
        {
            _context.SemesterCompany.Update(semesterCompany);
            await _context.SaveChangesAsync();
            return semesterCompany;
        }

        public async Task<bool> DeleteSemesterCompany(int semesterCompanyId)
        {
            var foundInSemesterCompany = await _context.SemesterCompany
                .FirstOrDefaultAsync(sc => sc.SemesterCompanyId == semesterCompanyId);
            if (foundInSemesterCompany == null)
                return false;
            // TODO: Check if there are no relation to the key
            _context.SemesterCompany.Remove(foundInSemesterCompany);

            return true;
        }
    }
}