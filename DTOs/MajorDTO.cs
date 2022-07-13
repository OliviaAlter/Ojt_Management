#nullable disable

using System.Collections.Generic;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class MajorDTO
    {
        public MajorDTO()
        {
            StudentDtos = new HashSet<StudentDTO>();
            RecruitInfoDtos = new HashSet<RecruitInfoDTO>();
        }
        
        public int MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<StudentDTO> StudentDtos { get; set; }
        public virtual ICollection<RecruitInfoDTO> RecruitInfoDtos { get; set; }
    }

}