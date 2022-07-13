#nullable disable

using System.Collections.Generic;

namespace OJTManagementAPI.DTOS
{
    public class MajorDTO
    {
        public MajorDTO()
        {
            Users = new HashSet<UserDTO>();
        }

        public int MajorId { get; set; }
        public string MajorName { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; }
    }
}