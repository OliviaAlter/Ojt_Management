#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class SemesterDTO
    {
        public SemesterDTO()
        {
            StudentDtOs = new HashSet<StudentDTO>();
        }


        public int SemesterId { get; set; }
        public string SemesterNumber { get; set; }

        public virtual ICollection<StudentDTO> StudentDtOs { get; set; }
    }
}