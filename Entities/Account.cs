using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Account
    {
        [Required] public int AccountId { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required] public int RoleId { get; set; }

        public virtual Role Roles { get; set; }
        public virtual Student Student { get; set; }
    }
}