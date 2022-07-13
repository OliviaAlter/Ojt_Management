#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Semester
    {
        public Semester()
        {
            RecruitInfos = new HashSet<RecruitInfo>();
        }
        
        [Required]
        public int SemesterId { get; set; }
        
        [Required]
        public int SemesterNumber { get; set; }

        public virtual ICollection<RecruitInfo> RecruitInfos { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}