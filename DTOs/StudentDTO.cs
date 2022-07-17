using System.Collections.Generic;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            JobApplicationDtos = new HashSet<JobApplicationDTO>();
        }

        public int StudentId { get; set; }
        public int AccountId { get; set; }
        public int StudentCode { get; set; }
        public string Name { get; set; }
        public int MajorId { get; set; }
        public int SemesterId { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public int? Score { get; set; }

        public virtual Major Major { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<JobApplicationDTO> JobApplicationDtos { get; set; }
    }
}