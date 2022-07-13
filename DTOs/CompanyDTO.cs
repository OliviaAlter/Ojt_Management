#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class CompanyDTO
    {
        public CompanyDTO()
        {
            SemesterCompanies = new HashSet<SemesterCompanyDTO>();
            UserCompanies = new HashSet<UserCompanyDTO>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<SemesterCompanyDTO> SemesterCompanies { get; set; }
        public virtual ICollection<UserCompanyDTO> UserCompanies { get; set; }
    }
}