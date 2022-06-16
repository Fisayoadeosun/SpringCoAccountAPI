namespace SpringCoAccountAPI.Models
{
    public class FundCustomerAccountDTO
    {
        public Guid CustomerId { get; set; }
        public decimal DepositAmount { get; set; }
        public string? AccountType { get; set; }
    }
}
