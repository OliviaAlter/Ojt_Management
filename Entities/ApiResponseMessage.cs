namespace OJTManagementAPI.Entities
{
    public class ApiResponseMessage
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}