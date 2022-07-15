﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OJTManagementAPI.DataContext;

namespace OJTManagementAPI.Migrations
{
    [DbContext(typeof(OjtManagementContext))]
    partial class OjtManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OJTManagementAPI.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.JobApplication", b =>
                {
                    b.Property<int>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationStatus")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecruitInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("StudentId");

                    b.ToTable("JobApplication");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MajorId");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterId");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.SemesterCompany", b =>
                {
                    b.Property<int>("SemesterCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("SemesterCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SemesterCompany");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Score")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("StudentCode")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("MajorId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Account", b =>
                {
                    b.HasOne("OJTManagementAPI.Entities.Role", "Roles")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Company", b =>
                {
                    b.HasOne("OJTManagementAPI.Entities.Account", "Account")
                        .WithOne("Companies")
                        .HasForeignKey("OJTManagementAPI.Entities.Company", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.JobApplication", b =>
                {
                    b.HasOne("OJTManagementAPI.Entities.Student", "Student")
                        .WithMany("JobApplications")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.SemesterCompany", b =>
                {
                    b.HasOne("OJTManagementAPI.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("OJTManagementAPI.Entities.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.Navigation("Company");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Student", b =>
                {
                    b.HasOne("OJTManagementAPI.Entities.Account", "Account")
                        .WithOne("Students")
                        .HasForeignKey("OJTManagementAPI.Entities.Student", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OJTManagementAPI.Entities.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OJTManagementAPI.Entities.Semester", "Semester")
                        .WithMany("Students")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Major");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Account", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Major", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Semester", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("OJTManagementAPI.Entities.Student", b =>
                {
                    b.Navigation("JobApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
