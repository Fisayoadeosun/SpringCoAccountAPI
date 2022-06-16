namespace SpringCoAccountAPI.Models
{
    public class CreateCustomerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNo { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deleted { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
