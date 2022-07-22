using AutoMapper;
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

            // Company DTO
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, CompanyListDTO>().ReverseMap();
            CreateMap<Company, CompanyUpdateDTO>().ReverseMap();

            // Account DTO
            CreateMap<Account, RegisterAccountDTO>().ReverseMap();
            CreateMap<Account, LoginAccountDTO>().ReverseMap();

            // Major DTOs
            CreateMap<Major, MajorUpdateDTO>().ReverseMap();
            CreateMap<Major, AddMajorDTO>().ReverseMap();

            // Semester Company DTOs
            CreateMap<SemesterCompany, SemesterCompanyDTO>().ReverseMap();

            // Semester DTOs
            CreateMap<Semester, AddSemesterDTO>().ReverseMap();

            // Student DTOs
            CreateMap<Student, RegisterStudentDTO>().ReverseMap();

            // Job Application DTOs
            CreateMap<JobApplication, AddJobApplicationDTO>().ReverseMap();
        }
    }
}