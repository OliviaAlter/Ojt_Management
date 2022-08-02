#nullable disable

using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class CompanyAddDTO
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public virtual AccountDTO Account { get; set; }
    }
}