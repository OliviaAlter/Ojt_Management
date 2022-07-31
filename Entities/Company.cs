#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Company
    {
        public Company()
        {
            JobApplications = new HashSet<JobApplication>();
            Jobs = new HashSet<Job>();
        }

        [Required] public int CompanyId { get; set; }

        [Required] public string CompanyName { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string CompanyEmail { get; set; }
        [Required] public int AccountId { get; set; }

        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual Account Account { get; set; }
    }
}