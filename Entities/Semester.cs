#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Semester
    {
        public Semester()
        {
            Students = new HashSet<Student>();
        }
        
        [Required]
        public int SemesterId { get; set; }
        
        [Required]
        public string SemesterName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}