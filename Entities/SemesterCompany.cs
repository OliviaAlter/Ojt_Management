using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class SemesterCompany
    {
        public int SemesterCompanyId { get; set; }
        public int? SemesterId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Semester Semester { get; set; }
    }
}