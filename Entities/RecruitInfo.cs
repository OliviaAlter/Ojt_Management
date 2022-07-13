using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class RecruitInfo
    {
        public RecruitInfo()
        {
            JobApplications = new HashSet<JobApplication>();
        }
        
        [Required]
        public int RecruitInfoId { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
       
        [Required]
        public int MajorId { get; set; }
       
        [Required]
        public int SemesterId { get; set; } 
        
        public virtual Company Company { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Major Major { get; set; }    
        public virtual ICollection<JobApplication> JobApplications { get; set; }

    }
}