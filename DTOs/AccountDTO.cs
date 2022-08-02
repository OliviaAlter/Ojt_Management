using System.ComponentModel.DataAnnotations;

namespace OJTManagementAPI.DTOS
{
    public class AccountDTO
    {
        [Required(ErrorMessage="Username must required.")]
        [MinLength(6)]
        [MaxLength(32)]
        public string Username { get; set; }
        [Required(ErrorMessage="Password must required.")]
        [MinLength(6)]
        public string Password { get; set; }
        [Required(ErrorMessage="Please enter @fpt.edu.vn mail.")]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@fpt.edu.vn",ErrorMessage="Please enter @fpt.edu.vn mail.")]
        public string Email { get; set; }
        //public virtual RoleDTO RoleDto { get; set; }
        //public virtual CompanyDTO CompanyDto { get; set; }
        //public virtual StudentDTO StudentDto { get; set; }
    }
}