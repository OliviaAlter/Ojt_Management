using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.ServiceInterfaces
{
    public interface IJobApplicationService
    {
        public Task<IEnumerable<JobApplication>> GetJobApplicationList();
        public Task<JobApplication> AddJobApplication(JobApplication account);
        public Task<JobApplication> UpdateApplication(JobApplication account);
        public Task<bool> DeleteApplication(int jobApplicationId);
        public IQueryable<JobApplication> GetJobApplicationById(int jobApplicationId);
        public IQueryable<JobApplication> GetJobApplicationByStudentId(int studentId);
        public IQueryable<JobApplication> GetJobApplicationByCompanyId(int companyId);
        public IQueryable<JobApplication> GetJobApplicationByMajorId(int majorId);

    }
}