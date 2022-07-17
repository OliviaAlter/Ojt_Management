using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class JobApplicationDTO
    {
        public int JobApplicationId { get; set; }
        public int? StudentId { get; set; }
        public string ImageUrl { get; set; }
        public int? ApplicationStatus { get; set; }

        public virtual Student Student { get; set; }
        public virtual Company Company { get; set; }
    }
}