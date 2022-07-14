using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface ISemesterCompanyService
    {
        public Task<List<SemesterCompany>> GetSemesterCompany();
        public Task<SemesterCompany> AddSemesterCompany(SemesterCompany semesterCompany);
        public Task<SemesterCompany> UpdateSemesterCompany(SemesterCompany semesterCompany);
        public Task<bool> DeleteSemesterCompany(int semesterCompanyId);
    }
}