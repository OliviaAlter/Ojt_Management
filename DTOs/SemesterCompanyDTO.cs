namespace OJTManagementAPI.DTOS
{
    public class SemesterCompanyDTO
    {
        public int SemesterCompanyId { get; set; }
        public int? SemesterId { get; set; }
        public int? CompanyId { get; set; }

        public virtual CompanyDTO Company { get; set; }
        public virtual SemesterDTO Semester { get; set; }
    }
}