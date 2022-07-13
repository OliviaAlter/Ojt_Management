using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            AccountDtos = new HashSet<AccountDTO>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<AccountDTO> AccountDtos { get; set; }
    }
}