#nullable disable

using System;
using Microsoft.EntityFrameworkCore;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DataContext
{
    public class OjtManagementContext : DbContext
    {
        public OjtManagementContext()
        {
        }

        public OjtManagementContext(DbContextOptions<OjtManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterCompany> SemesterCompanies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCompany> UserCompanies { get; set; }
        public virtual DbSet<UserSemester> UserSemesters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Semester>(entity => { entity.ToTable("Semester"); });

            modelBuilder.Entity<SemesterCompany>(entity =>
            {
                entity.ToTable("SemesterCompany");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SemesterCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__SemesterC__Compa__398D8EEE");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterCompanies)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__SemesterC__Semes__38996AB5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__MajorId__2C3393D0");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__2B3F6F97");
            });

            modelBuilder.Entity<UserCompany>(entity =>
            {
                entity.ToTable("UserCompany");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__UserCompa__Compa__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserCompa__UserI__34C8D9D1");
            });

            modelBuilder.Entity<UserSemester>(entity =>
            {
                entity.ToTable("UserSemester");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.UserSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__UserSemes__Semes__31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSemesters)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserSemes__UserI__30F848ED");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}