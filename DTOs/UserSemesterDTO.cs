#nullable disable

namespace OJTManagementAPI.DTOS
{
    public class UserSemesterDTO
    {
        public int UserSemesterId { get; set; }
        public int? UserId { get; set; }
        public int? SemesterId { get; set; }

        public virtual SemesterDTO Semester { get; set; }
        public virtual UserDTO User { get; set; }
    }
}