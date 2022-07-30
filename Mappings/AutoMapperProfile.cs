using AutoMapper;
using OJTManagementAPI.DTOs;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Basic DTO
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Major, MajorDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<SemesterCompany, SemesterCompanyDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();

            // Company DTO
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, CompanyListDTO>().ReverseMap();
            CreateMap<Company, CompanyUpdateDTO>().ReverseMap();

            // Account DTO
            CreateMap<Account, RegisterAccountDTO>().ReverseMap();
            CreateMap<Account, LoginAccountDTO>().ReverseMap();

            // Major DTOs
            CreateMap<Major, MajorUpdateDTO>().ReverseMap();
            CreateMap<Major, MajorAddDTO>().ReverseMap();

            // Semester Company DTOs
            CreateMap<SemesterCompany, SemesterCompanyDTO>().ReverseMap();
            CreateMap<SemesterCompany, SemesterCompanyAddDTO>().ReverseMap();

            // Semester DTOs
            CreateMap<Semester, SemesterAddDTO>().ReverseMap();

            // Student DTOs
            CreateMap<Student, RegisterStudentDTO>().ReverseMap();

            // Job Application DTOs
            CreateMap<JobApplication, AddJobApplicationDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationUpdateDTO>().ReverseMap();
            CreateMap<JobApplication, AddJobApplicationDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationUpdateDTO>().ReverseMap();
            
            // Job DTOs
            CreateMap<Job, JobAddDTO>().ReverseMap();
            CreateMap<Job, JobUpdateDTO>().ReverseMap();

        }
    }
}