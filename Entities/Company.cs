#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.Entities
{
    public class Company
    {
        public Company()
        {
            SemesterCompanies = new HashSet<SemesterCompany>();
            UserCompanies = new HashSet<UserCompany>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<SemesterCompany> SemesterCompanies { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}