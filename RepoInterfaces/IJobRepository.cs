using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.RepoInterfaces
{
    public interface IJobRepository
    {
        public IQueryable<Job> GetJobList();
        public IQueryable<Job> GetJobByName(string name);
        public IQueryable<Job> GetJobById(int applicationId);
        public IQueryable<Job> GetJobListContainName(string name);
        public IQueryable<Job> GetJobData(Job job);
        public Task<Job> AddJob(Job job);
        public Task<Job> UpdateJob(int id, Job job);
        public Task<Job> DeleteJob(int id);
    }
}