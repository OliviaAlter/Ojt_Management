using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IJobApplicationService
    {
        public Task<List<JobApplication>> GetJobApplication();
        public Task<JobApplication> AddJobApplication(JobApplication account);
        public Task<JobApplication> UpdateApplication(JobApplication account);
        public Task<bool> DeleteApplication(int jobApplicationId);
    }
}