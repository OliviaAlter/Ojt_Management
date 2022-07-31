using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Job
    {
        [Required]
        public int JobId { get; set; }
        [Required]
        public string JobName { get; set; }
        [Required]
        public int MajorId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string Status { get; set; }
        
        public virtual Major Major { get; set; }
        public virtual Company Company { get; set; }
        
    }
}