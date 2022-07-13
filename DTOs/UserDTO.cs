#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class UserDTO
    {
        public UserDTO()
        {
            UserCompanies = new HashSet<UserCompanyDTO>();
            UserSemesters = new HashSet<UserSemesterDTO>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int MajorId { get; set; }

        public virtual MajorDTO Major { get; set; }
        public virtual RoleDTO Role { get; set; }
        public virtual ICollection<UserCompanyDTO> UserCompanies { get; set; }
        public virtual ICollection<UserSemesterDTO> UserSemesters { get; set; }
    }
}