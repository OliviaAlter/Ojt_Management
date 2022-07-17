#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class MajorDTO
    {
        public MajorDTO()
        {
            StudentDtos = new HashSet<StudentDTO>();
        }

        public int MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<StudentDTO> StudentDtos { get; set; }
    }
}