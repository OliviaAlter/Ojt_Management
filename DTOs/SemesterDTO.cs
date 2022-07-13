#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class SemesterDTO
    {
        public SemesterDTO()
        {
            SemesterCompanies = new HashSet<SemesterCompanyDTO>();
            UserSemesters = new HashSet<UserSemesterDTO>();
        }

        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }

        public virtual ICollection<SemesterCompanyDTO> SemesterCompanies { get; set; }
        public virtual ICollection<UserSemesterDTO> UserSemesters { get; set; }
    }
}