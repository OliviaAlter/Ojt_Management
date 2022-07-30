using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly OjtManagementContext _context;
        
        public JobRepository(OjtManagementContext context)
        {
            _context = context;
        }


        public IQueryable<Job> GetJobList()
        {
            return _context.Job;
        }

        public IQueryable<Job> GetJobByName(string name)
        {
            return _context.Job.Where(a => string.Equals(a.JobName, name,
                StringComparison.CurrentCultureIgnoreCase));
        }

        public IQueryable<Job> GetJobById(int id)
        {
            return _context.Job
                .Where(x => x.JobId == id);
            
        }

        public IQueryable<Job> GetJobListContainName(string name)
        {
            return _context.Job
                .Where(a => a.JobName.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<Job> GetJobData(Job job)
        {
            return _context.Job
                .Where(a => a.JobId == job.JobId)
                .Include(b => b.Company)
                .Include(c => c.Major);
        }

        public async Task<Job> AddJob(Job job)
        {
            await _context.Job.AddAsync(job);
            await _context.SaveChangesAsync();
            return job;        
        }

        public async Task<Job> UpdateJob(int id, Job job)
        {
            // TODO : update job with constraint
            _context.Job.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<Job> DeleteJob(int id)
        {
            // TODO : Check if the job is in use or not.
            return null;
        }
    }
}