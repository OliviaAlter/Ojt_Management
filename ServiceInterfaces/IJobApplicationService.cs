using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IJobApplicationService
    {
        public Task<IEnumerable<JobApplication>> GetJobApplicationList();
        public Task<JobApplication> AddJobApplication(JobApplication application);
        public Task<JobApplication> UpdateApplication(int id, JobApplication application);
        public Task<bool> DeleteApplication(int jobApplicationId);
        public Task<JobApplication> UpdateApplicationStatus(int id, JobApplication application);
        public Task<JobApplication> GetJobApplicationById(int jobApplicationId);
        public Task<IEnumerable<JobApplication>> GetJobApplicationByStudentId(int studentId);
        public Task<IEnumerable<JobApplication>> GetJobApplicationByCompanyId(int companyId);
        public Task<IEnumerable<JobApplication>> GetJobApplicationByMajorId(int majorId);
    }
}