using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.DTOS
{
    public class LoginAccountDTO
    {
        [Required]
        //[MaxLength(32,ErrorMessage="The email or password is incorrect")]
        //[MinLength(6,ErrorMessage = "The email or password is incorrect")]
        public string Email { get; set; }
        [Required]
        //[MaxLength(32,ErrorMessage="The email or password is incorrect")]
        //[MinLength(6,ErrorMessage = "The email or password is incorrect")]
        public string Password { get; set; }
    }
}