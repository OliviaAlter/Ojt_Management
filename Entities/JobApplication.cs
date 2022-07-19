using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class JobApplication
    {
        [Required] public int JobApplicationId { get; set; }

        [Required] public int StudentId { get; set; }

        [Required] public string ImageUrl { get; set; }
        public int? ApplicationStatus { get; set; }

        public virtual Student Student { get; set; }
        public virtual Company Company { get; set; }
    }
}