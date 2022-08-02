using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class JobApplicationUpdateDTO
    {
        public int JobApplicationId { get; set; }
        public int? StudentId { get; set; }
        public string ImageUrl { get; set; }
        public int? ApplicationStatus { get; set; }

        public virtual StudentDTO Student { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}