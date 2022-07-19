using OJTManagementAPI.Entities;

namespace OJTManagementAPI.DTOS
{
    public class RegisterStudentDTO
    {
        public int StudentId { get; set; }
        public int AccountId { get; set; }
        public int StudentCode { get; set; }
        public string Name { get; set; }
        public int MajorId { get; set; }
        public int SemesterId { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
    }
}