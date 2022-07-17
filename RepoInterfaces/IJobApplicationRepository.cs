using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IJobApplicationRepository
    {
      
        public IQueryable<JobApplication> GetApplicationList();
        public IQueryable<JobApplication> GetJobApplicationById(int applicationId);
        public IQueryable<JobApplication> GetJobApplicationListByStudentId(int studentId);
        public IQueryable<JobApplication> GetJobApplicationListByCompanyId(int companyId);
        public IQueryable<JobApplication> GetJobApplicationListByMajorId(int majorId);
        public Task<JobApplication> AddApplication(JobApplication application);
        public Task<JobApplication> UpdateApplication(JobApplication application);
        public Task<bool> DeleteApplication(int applicationId);
    }
}