using System.Collections.Generic;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IJobService
    {
        public Task<IEnumerable<Job>> GetJobList();
        public Task<IEnumerable<Job>> GetJobListContainName(string name);
        public Task<Job> GetJobById(int id);
        public Task<Job> AddJob(Job job);
        public Task<Job> UpdateJob(int id, Job job);
        public Task<Job> GetJobData(Job job);
        public Task<bool> DeleteJobAdmin(int id);
        public Task<bool> DeleteJobCompany(int id, int companyId);
    }
}