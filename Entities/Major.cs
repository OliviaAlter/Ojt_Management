#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.Entities
{
    public class Major
    {
        public Major()
        {
            Users = new HashSet<User>();
        }

        public int MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}