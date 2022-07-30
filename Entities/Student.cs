using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Student
    {
        public Student()
        {
            JobApplications = new HashSet<JobApplication>();
        }

        [Required] public int StudentId { get; set; }
        [Required] public int AccountId { get; set; }
        [Required] public int StudentCode { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int MajorId { get; set; }
        [Required] public int SemesterId { get; set; }
        public int? PhoneNumber { get; set; }
        public int? Score { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        public virtual Major Major { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}