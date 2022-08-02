
namespace OJTManagementAPI.DTOS
{
    public class AddJobApplicationDTO
    {
        public int JobApplicationId { get; set; }
        public int StudentId { get; set; }
        public string ApplicationStatus { get; set; }
        public virtual StudentDTO Student { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}