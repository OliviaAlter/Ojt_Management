using System.Collections.Generic;
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

        public async Task<List<JobApplication>> GetApplicationLists()
        {
            return await _context.JobApplication.ToListAsync();
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