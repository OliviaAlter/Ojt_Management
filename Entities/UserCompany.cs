#nullable disable

namespace OJTManagementAPI.Entities
{
    public class UserCompany
    {
        public int UserCompanyId { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}