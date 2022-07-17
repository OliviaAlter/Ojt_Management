using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;
using OJTManagementAPI.ServiceInterfaces;

namespace OJTManagementAPI.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _applicationRepository;

        public JobApplicationService(IJobApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationList()
        {
            return await _applicationRepository.GetApplicationList()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<JobApplication>> GetJobApplicationByStudentId(int studentId)
        {
            return await _applicationRepository.GetJobApplicationListByStudentId(studentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationByCompanyId(int companyId)
        {
            return await _applicationRepository.GetJobApplicationListByCompanyId(companyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationByMajorId(int majorId)
        {
            return await _applicationRepository.GetJobApplicationListByMajorId(majorId)
                .ToListAsync();
        }
        
        public async Task<JobApplication> GetJobApplicationById(int jobApplicationId)
        {
            return await _applicationRepository.GetJobApplicationById(jobApplicationId)
                .FirstOrDefaultAsync();
        }
        
        public async Task<JobApplication> AddJobApplication(JobApplication application)
        {
            return await _applicationRepository.AddApplication(application);
        }

        public async Task<JobApplication> UpdateApplication(JobApplication application)
        {
            return await _applicationRepository.UpdateApplication(application);
        }

        public async Task<bool> DeleteApplication(int jobApplicationId)
        {
            return await _applicationRepository.DeleteApplication(jobApplicationId);
        }

    }
}