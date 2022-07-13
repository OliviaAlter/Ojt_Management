#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.Entities
{
    public class Semester
    {
        public Semester()
        {
            SemesterCompanies = new HashSet<SemesterCompany>();
            UserSemesters = new HashSet<UserSemester>();
        }

        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }

        public virtual ICollection<SemesterCompany> SemesterCompanies { get; set; }
        public virtual ICollection<UserSemester> UserSemesters { get; set; }
    }
}