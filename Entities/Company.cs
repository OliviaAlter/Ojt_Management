#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Company
    {
        [Required]
        public int CompanyId { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Email { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}