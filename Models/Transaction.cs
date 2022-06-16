namespace SpringCoAccountAPI.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? TransactionType { get; set; }
        public string? Purpose { get; set; }
        public string? RefrenceId { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountDebited { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? TransactionStatus { get; set; }
    }
}
