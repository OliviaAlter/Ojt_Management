using System.ComponentModel.DataAnnotations;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOs
{
    public class JobDTO
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
        public int JobDescription { get; set; }
        [Required]
        public string Status { get; set; }
    }
}