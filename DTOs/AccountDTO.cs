namespace OJTManagementAPI.DTOS
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual RoleDTO RoleDto { get; set; }
        public virtual CompanyDTO CompanyDto { get; set; }
        public virtual StudentDTO StudentDto { get; set; }
    }
}