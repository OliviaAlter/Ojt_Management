using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _semesterRepository;

        public SemesterService(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public async Task<IEnumerable<Semester>> GetSemesterList()
        {
            return await _semesterRepository.GetSemesterList()
                .ToListAsync();
        }

        public async Task<IEnumerable<Semester>> GetSemesterByName(string semesterName)
        {
            return await _semesterRepository.GetSemesterName(semesterName)
                .ToListAsync();
        }

        public async Task<Semester> GetSemesterById(int semesterId)
        {
            return await _semesterRepository.GetSemesterById(semesterId)
                .FirstOrDefaultAsync();
        }

        public async Task<Semester> AddSemester(Semester semester)
        {
            return await _semesterRepository.AddSemester(semester);
        }

        public async Task<Semester> UpdateSemester(Semester semester)
        {
            return await _semesterRepository.UpdateSemester(semester);
        }

        public async Task<bool> DeleteSemester(int semesterId)
        {
            return await _semesterRepository.DeleteSemester(semesterId);
        }
    }
}