using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IJobApplicationRepository
    {
        public Task<List<JobApplication>> GetApplicationLists();
        public Task<JobApplication> AddApplication(JobApplication application);
        public Task<JobApplication> UpdateApplication(JobApplication application);
        public Task<bool> DeleteApplication(int applicationId);
    }
}