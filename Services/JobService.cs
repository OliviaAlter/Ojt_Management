using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetJobList()
        {
            return await _jobRepository.GetJobList()
                .ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetJobListContainName(string name)
        {
            return await _jobRepository.GetJobListContainName(name)
                .ToListAsync();        
        }

        public async Task<Job> GetJobById(int id)
        {
            return await _jobRepository.GetJobById(id)
                .FirstOrDefaultAsync();
        }

        public async Task<Job> AddJob(Job job)
        {
            return await _jobRepository.AddJob(job);
        }

        public async Task<Job> UpdateJob(int id, Job job)
        {
            return await _jobRepository.UpdateJob(id, job);
        }
        
        public async Task<Job> GetJobData(Job job)
        {
            return await _jobRepository.GetJobData(job)
                .FirstOrDefaultAsync();        
        }

        public async Task<bool> DeleteJobAdmin(int id)
        {
            return await _jobRepository.DeleteJobAdmin(id);
        }

        public async Task<bool> DeleteJobCompany(int id, int companyId)
        {
            return await _jobRepository.DeleteJobCompany(id, companyId);
        }
    }
}