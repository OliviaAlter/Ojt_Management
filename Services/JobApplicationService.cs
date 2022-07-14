using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        public Task<List<JobApplication>> GetJobApplication()
        {
            throw new System.NotImplementedException();
        }

        public Task<JobApplication> AddJobApplication(JobApplication account)
        {
            throw new System.NotImplementedException();
        }

        public Task<JobApplication> UpdateApplication(JobApplication account)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteApplication(int jobApplicationId)
        {
            throw new System.NotImplementedException();
        }
    }
}