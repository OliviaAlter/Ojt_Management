using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IJobApplicationRepository
    {
        public Task<IEnumerable<JobApplication>> GetApplicationLists();
        public Task<JobApplication> AddApplication(JobApplication application);
        public Task<JobApplication> UpdateApplication(JobApplication application);
        public Task<bool> DeleteApplication(int applicationId);
        public IQueryable<JobApplication> GetJobApplicationById(int applicationId);
        public IQueryable<JobApplication> GetJobApplicationByStudentId(int studentId);
        public IQueryable<JobApplication> GetJobApplicationByCompanyId(int companyId);
        public IQueryable<JobApplication> GetJobApplicationByMajorId(int majorId);

    }
}