using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class SemesterCompanyRepository : ISemesterCompanyRepository
    {
        private readonly OjtManagementContext _context;

        public SemesterCompanyRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyList()
        {
            return _context.SemesterCompany;
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyListBySemesterName(string semesterName)
        {
            return _context.SemesterCompany
                .Where(x => x.Semester.SemesterName == semesterName);
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyBySemesterId(int semesterId)
        {
            return _context.SemesterCompany
                .Where(x => x.Semester.SemesterId == semesterId);
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyListByCompanyName(string companyName)
        {
            return _context.SemesterCompany
                .Where(x => x.Company.CompanyName.ToLower().Contains(companyName.ToLower()));
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyByCompanyId(int companyId)
        {
            return _context.SemesterCompany
                .Where(x => x.Company.CompanyId == companyId);
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyById(int semesterCompanyId)
        {
            return _context.SemesterCompany
                .Where(x => x.Semester.SemesterId == semesterCompanyId);
        }

        public IQueryable<SemesterCompany> GetSemesterCompanyByName(string semesterCompanyName)
        {
            return _context.SemesterCompany
                .Where(x => string.Equals(x.Semester.SemesterName, semesterCompanyName,
                    StringComparison.CurrentCultureIgnoreCase));
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