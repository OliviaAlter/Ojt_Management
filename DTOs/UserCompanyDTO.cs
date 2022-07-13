#nullable disable

namespace OJTManagementAPI.DTOS
{
    public class UserCompanyDTO
    {
        public int UserCompanyId { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }

        public virtual CompanyDTO Company { get; set; }
        public virtual UserDTO User { get; set; }
    }
}