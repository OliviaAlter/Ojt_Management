#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.Entities
{
    public class User
    {
        public User()
        {
            UserCompanies = new HashSet<UserCompany>();
            UserSemesters = new HashSet<UserSemester>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
        public virtual ICollection<UserSemester> UserSemesters { get; set; }
    }
}