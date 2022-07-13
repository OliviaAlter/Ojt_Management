#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Company
    {
        public Company()
        {
            RecruitInfos = new HashSet<RecruitInfo>();
        }
        
        [Required]
        public int CompanyId { get; set; }
        
        [Required]
        public string CompanyName { get; set; }
        
        [Required]
        public int AccountId { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Email { get; set; }

        
        public virtual Account Account { get; set; }
        public virtual ICollection<RecruitInfo> RecruitInfos { get; set; }
    }
}