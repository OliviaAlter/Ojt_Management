
using OJTManagementAPI.DTOs;

namespace OJTManagementAPI.DTOS
{
    public class AddJobApplicationDTO
    {
        public int StudentId { get; set; }
        public string ApplicationStatus { get; set; }
        public virtual StudentAddJobDTO Student { get; set; }
        public virtual CompanyAddJobDTO Company { get; set; }
    }
}