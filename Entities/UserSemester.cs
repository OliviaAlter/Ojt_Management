#nullable disable

namespace OJTManagementAPI.Entities
{
    public class UserSemester
    {
        public int UserSemesterId { get; set; }
        public int? UserId { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual User User { get; set; }
    }
}