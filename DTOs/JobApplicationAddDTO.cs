using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class AddJobApplicationDTO
    {
        public int JobApplicationId { get; set; }
        public int StudentId { get; set; }
        public string ApplicationStatus { get; set; }
        public virtual Student Student { get; set; }
        public virtual Company Company { get; set; }
    }
}