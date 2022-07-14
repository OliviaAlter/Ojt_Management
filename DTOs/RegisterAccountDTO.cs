using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.DTOS
{
    public class RegisterAccountDTO
    {
        [Required] 
        [MinLength(6)]
        [MaxLength(32)]
        public string Username { get; set; } 
        [Required]
        [MinLength(6)]
        [MaxLength(32)]
        public string Password { get; set; }
        [DefaultValue(1)]
        public int RoleId { get; set; }
        
        
    }
}