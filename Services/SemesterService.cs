using System.Collections.Generic;
using System.Threading.Tasks;
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
            return await _semesterRepository.GetSemesters();
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