using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class JobApplicationDTO
    {
        public int JobApplicationId { get; set; }   
        public int RecruitInfoId { get; set; }
        public int? StudentId { get; set; }
        public string ImageUrl { get; set; }
        public int? ApplicationStatus { get; set; }
            
        public virtual Student Student { get; set; }
    }
    
}