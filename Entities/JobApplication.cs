using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OJTManagementAPI.Entities
{
    public class JobApplication
    {
        [Required]
        public int JobApplicationId { get; set; }   
        
        [Required]
        public int RecruitInfoId { get; set; }
        
        public int? StudentId { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public int JobApplicationStatusId { get; set; }

        public virtual JobApplicationStatus JobApplicationStatus { get; set; }
        public virtual RecruitInfo RecruitInfo { get; set; }   
        public virtual Student Student { get; set; }
        
    }
}