using AutoMapper;
using OJTManagementAPI.DTOS;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Major, MajorDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<SemesterCompany, SemesterCompanyDTO>().ReverseMap();
            CreateMap<JobApplication, JobApplicationDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Account, RegisterAccountDTO>().ReverseMap();
        }
    }
}