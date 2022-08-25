namespace eOffice.Onboarding.Models
{
    public class SystemAccountModel
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public DateTime BirthDate { get; set; }
        public bool CreateEOfficeAccount { get; set; }
        public bool CreateEmail { get; set; }
        public string Message { get; set; }
    }
}
