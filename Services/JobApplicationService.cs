using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await _applicationRepository.GetApplicationLists();
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

        public IQueryable<JobApplication> GetJobApplicationById(int jobApplicationId)
        {
            return _applicationRepository.GetJobApplicationById(jobApplicationId);
        }

        public IQueryable<JobApplication> GetJobApplicationByStudentId(int studentId)
        {
            return _applicationRepository.GetJobApplicationByStudentId(studentId);
        }

        public IQueryable<JobApplication> GetJobApplicationByCompanyId(int companyId)
        {
            return _applicationRepository.GetJobApplicationByCompanyId(companyId);
        }

        public IQueryable<JobApplication> GetJobApplicationByMajorId(int majorId)
        {
            return _applicationRepository.GetJobApplicationByMajorId(majorId);
        }
    }
}