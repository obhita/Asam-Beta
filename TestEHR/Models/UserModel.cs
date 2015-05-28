namespace TestEHR.Models
{
    public class UserModel
    {
        public long EhrId { get; set; }
        public long OrganizationId { get; set; }
        public string Username { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
        public long PatientId { get; set; }
        public string ApiKey { get; set; }
    }
}