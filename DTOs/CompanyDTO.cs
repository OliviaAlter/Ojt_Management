#nullable disable

using System.Collections.Generic;
using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual Account Account { get; set; }
    }
}