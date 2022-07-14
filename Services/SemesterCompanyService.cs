using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class SemesterCompanyService : ISemesterCompanyService
    {
        public Task<List<SemesterCompany>> GetSemesterCompany()
        {
            throw new System.NotImplementedException();
        }

        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteSemesterCompany(int semesterCompanyId)
        {
            throw new System.NotImplementedException();
        }
    }
}