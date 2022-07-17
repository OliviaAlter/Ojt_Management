using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.Entities;
using OJTManagementAPI.RepoInterfaces;

namespace OJTManagementAPI.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly OjtManagementContext _context;

        public JobApplicationRepository(OjtManagementContext context)
        {
            _context = context;
        }

        public IQueryable<JobApplication> GetApplicationList()
        {
            return _context.JobApplication;
        }

        public IQueryable<JobApplication> GetJobApplicationById(int applicationId)
        {
            return _context.JobApplication
                .Where(x => x.JobApplicationId == applicationId);
        }

        public IQueryable<JobApplication> GetJobApplicationListByStudentId(int studentId)
        {
            return _context.JobApplication
                .Where(x => x.Student.StudentId == studentId);
        }

        public IQueryable<JobApplication> GetJobApplicationListByCompanyId(int companyId)
        {
            return _context.JobApplication
                .Where(x => x.Company.CompanyId == companyId);
        }

        public IQueryable<JobApplication> GetJobApplicationListByMajorId(int majorId)
        {
            return _context.JobApplication
                .Where(x => x.Student.MajorId == majorId);
        }
        
        public async Task<JobApplication> AddApplication(JobApplication application)
        {
            await _context.JobApplication.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<JobApplication> UpdateApplication(JobApplication application)
        {
            _context.JobApplication.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<bool> DeleteApplication(int applicationId)
        {
            var foundInApplication = await _context.JobApplication
                .FirstOrDefaultAsync(s => s.JobApplicationId == applicationId);


            if (foundInApplication == null)
                return false;

            _context.JobApplication.Remove(foundInApplication);

            //TODO: Check if the user is already in any OJT or haven't got status updated for the application

            await _context.SaveChangesAsync();
            return true;
        }

    }
}