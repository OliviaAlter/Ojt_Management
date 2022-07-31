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
            var jobData = await _context.Job
                .Where(x => x.JobId == id)
                .Include(y => y.Major)
                .FirstOrDefaultAsync();
            try
            {
                if (jobData != null)
                {
                    jobData.JobDescription ??= job.JobDescription;
                    jobData.JobName ??= job.JobName;
                    jobData.Major.MajorName ??= job.Major.MajorName;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return null;
            }
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteJobAdmin(int id)
        {
            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return false;
            }
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteJobCompany(int id, int companyId)
        {
            var companyCheck = _context.Company
                .Where(x => x.CompanyId == companyId)
                .FirstOrDefaultAsync();
            
            // check if companyId is matched with the current company
            if (companyCheck == null)
                return false;
            
            var job = _context.Job
                .Where(x => x.CompanyId == companyId)
                .FirstOrDefaultAsync(x => x.JobId == id);
            
            if (job == null)
                return false;
            
            _context.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}