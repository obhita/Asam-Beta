namespace TestEHR.Models
{
    public class RequestModel
    {
        public string Url { get; set; }
        public string PatientId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AssessmentId { get; set; }
        public string Timestamp { get; set; }
        public string Token { get; set; }
    }
}