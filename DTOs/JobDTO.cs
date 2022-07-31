using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.DTOs
{
    public class JobDTO
    {
        [Required] public int JobId { get; set; }

        [Required] public string JobName { get; set; }

        [Required] public int MajorId { get; set; }

        [Required] public int CompanyId { get; set; }

        [Required] public string JobDescription { get; set; }

        [Required] public string Status { get; set; }
    }
}