using System.Collections.Generic;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class RecruitInfoDTO
    {
        public RecruitInfoDTO()
        {
            JobApplications = new HashSet<JobApplicationDTO>();
        }
        
        public int RecruitInfoId { get; set; }
        public int CompanyId { get; set; }
        public int MajorId { get; set; }
        public int SemesterId { get; set; } 
        
        public virtual Company Company { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Major Major { get; set; }    
        public virtual ICollection<JobApplicationDTO> JobApplications { get; set; }
    }
}