#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            Users = new HashSet<UserDTO>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}