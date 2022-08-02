namespace OJTManagementAPI.Entities
{
    public class CompanyJob
    {
        public int CompanyJobId { get; set; }   
        public int JobId { get; set; }
        public int CompanyId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Company Company { get; set; }
    }
}