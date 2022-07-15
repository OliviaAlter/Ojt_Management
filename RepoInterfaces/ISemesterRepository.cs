using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterRepository
    {
        public Task<IEnumerable<Semester>> GetSemesters();
        public Task<IEnumerable<Semester>> GetSemesterName(string semesterName);
        public Task<IEnumerable<Semester>> GetSemesterId(int semesterId);
        public Task<Semester> AddSemester(Semester semesterCompany);
        public Task<Semester> UpdateSemester(Semester semesterCompany);
        public Task<bool> DeleteSemester(int semesterCompanyId);
    }
}