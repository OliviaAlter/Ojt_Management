#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Required]
        public int RoleId { get; set; } 
        
        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}