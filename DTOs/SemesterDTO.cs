#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class SemesterDTO
    {
        public SemesterDTO()
        {
            RecruitInfoDtOs = new HashSet<RecruitInfoDTO>();
            StudentDtOs = new HashSet<StudentDTO>();
        }
        
        
        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }

        public virtual ICollection<RecruitInfoDTO> RecruitInfoDtOs { get; set; }
        public virtual ICollection<StudentDTO> StudentDtOs { get; set; }
    }
}