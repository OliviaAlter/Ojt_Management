using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class JobApplicationDTO
    {
        public int JobApplicationId { get; set; }   
        public int RecruitInfoId { get; set; }
        public int? StudentId { get; set; }
        public string ImageUrl { get; set; }
        public int JobApplicationStatusId { get; set; }
        
        public virtual JobApplicationStatus JobApplicationStatus { get; set; }
        public virtual RecruitInfo RecruitInfo { get; set; }   
        public virtual Student Student { get; set; }
    }
    
}