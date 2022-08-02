using OJTManagementAPI.DTOS;

namespace OJTManagementAPI.DTOs
{
    public class CompanyJobDTO
    {
        public int CompanyJobId { get; set; }   
        public int JobId { get; set; }
        public int CompanyId { get; set; }

        public virtual JobDTO Job { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}