using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ISemesterService
    {
        public Task<IEnumerable<Semester>> GetSemesterList();
        public Task<IEnumerable<Semester>> GetSemesterByName(string semesterName);
        public Task<Semester> GetSemesterById(int semesterId);
        public Task<Semester> AddSemester(Semester account);
        public Task<Semester> UpdateSemester(Semester account);
        public Task<bool> DeleteSemester(int accountId);
    }
}