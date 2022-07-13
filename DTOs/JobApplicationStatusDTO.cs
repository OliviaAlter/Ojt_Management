using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.DTOS
{
    public class JobApplicationStatusDTO
    {
        public JobApplicationStatusDTO()
        {
            JobApplicationDtos = new HashSet<JobApplicationDTO>();
        }
        
        [Required]
        public int JobApplicationStatusId { get; set; }
        
        [Required]
        public string JobApplicationStatusName { get; set; }
        
        public virtual ICollection<JobApplicationDTO> JobApplicationDtos { get; set; }
    }
}