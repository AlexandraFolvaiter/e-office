namespace eOffice.SystemAccounts.Models
{
    public class SystemAccountsRequestGetModel : SystemAccountsRequestModel
    {
        public Guid Id { get; set; }
        public string? ResponseMessage { get; set; }
        public bool IsCompleted { get; set; }
    }
}