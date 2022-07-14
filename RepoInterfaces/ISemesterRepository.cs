using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface ISemesterRepository
    {
        public Task<List<Semester>> GetSemesters();
        public Task<List<Semester>> GetSemesterName(string semesterName);
        public Task<List<Semester>> GetSemesterId(int semesterId);
        public Task<Semester> AddSemester(Semester semesterCompany);
        public Task<Semester> UpdateSemester(Semester semesterCompany);
        public Task<bool> DeleteSemester(int semesterCompanyId);
    }
}