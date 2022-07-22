using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class SemesterCompany
    {
        [Required] public int SemesterCompanyId { get; set; }

        [Required] public int SemesterId { get; set; }

        [Required] public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Semester Semester { get; set; }
    }
}