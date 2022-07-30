#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        [Required] public int MajorId { get; set; }

        [Required] public string MajorName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Job> JobDetails { get; set; }
    }
}