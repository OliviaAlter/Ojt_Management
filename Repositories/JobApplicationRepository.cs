using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.DataContext;
using OJTManagementAPI.DTOS;
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

        public async Task<JobApplication> UpdateApplication(int id, JobApplicationUpdateDTO application)
        {
            var applicationData = await _context.JobApplication
                .FirstOrDefaultAsync(x => x.JobApplicationId == id);
            try
            {
                if (applicationData != null)
                {
                    applicationData.Company ??= application.Company;
                    applicationData.Student.Account.Email = application.Student.Account.Email;
                    applicationData.Student.Major ??= application.Student.Major;
                    applicationData.Student.Name ??= application.Student.Name;
                    applicationData.Student.Score ??= application.Student.Score;
                    applicationData.Student.Semester.SemesterName ??= application.Student.Semester.SemesterName;

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

            return applicationData;
        }
        
        public async Task<JobApplication> ChangeApplicationStatus(int id, JobApplicationStatusUpdateDTO application)
        {
            var applicationData = await _context.JobApplication
                .FirstOrDefaultAsync(x => x.JobApplicationId == id);
            try
            {
                if (applicationData != null)
                {
                    applicationData.ApplicationStatus ??= application.ApplicationStatus;

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

            return applicationData;
        }

        public async Task<bool> DeleteApplication(int applicationId)
        {
            try
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
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }
        }
    }
}