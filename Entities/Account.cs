using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.Entities
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required] public int RoleId { get; set; }
        [Required] public string Email { get; set; }

        public virtual Role Roles { get; set; }
        public virtual Student Student { get; set; }
    }
}