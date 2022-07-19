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
            
            // Create DTO
            CreateMap<Account, RegisterAccountDTO>().ReverseMap();
            CreateMap<Major, MajorUpdateDTO>().ReverseMap();
            CreateMap<Major, AddMajorDTO>().ReverseMap();
            CreateMap<SemesterCompany, SemesterCompanyDTO>().ReverseMap();
            CreateMap<Student, RegisterStudentDTO>().ReverseMap();
            CreateMap<Semester, AddSemesterDTO>().ReverseMap();
            CreateMap<JobApplication, AddJobApplicationDTO>().ReverseMap();
        }
    }
}