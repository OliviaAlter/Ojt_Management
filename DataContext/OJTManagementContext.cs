#nullable disable

using System;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DataContext
{
    public class OjtManagementContext : DbContext
    {
        public OjtManagementContext(DbContextOptions<OjtManagementContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<JobApplication> JobApplication { get; set; }
        public virtual DbSet<JobApplicationStatus> JobApplicationStatus { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<RecruitInfo> RecruitInfo { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Semester> Semester { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
        
    }
}