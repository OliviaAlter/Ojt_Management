namespace OJTManagementAPI.DataContext
{
    public class JobApplicationStatusUpdateDTO
    {
        public int JobApplicationId { get; set; }
        public int StudentId { get; set; }
        public string ApplicationStatus { get; set; }
    }
}