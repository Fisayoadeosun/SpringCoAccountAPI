namespace SpringCoAccountAPI.Models
{
    public class DebitCustomerAccountDTO
    {
        public Guid CustomerId { get; set; }
        public decimal DebitAmount { get; set; }
        public string? AccountType { get; set; }
    }
}
