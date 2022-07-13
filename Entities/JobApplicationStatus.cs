using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class JobApplicationStatus
    {
        public JobApplicationStatus()
        {
            JobApplications = new HashSet<JobApplication>();
        }
        
        [Required]
        public int JobApplicationStatusId { get; set; }
        
        [Required]
        public string JobApplicationStatusName { get; set; }
        
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}