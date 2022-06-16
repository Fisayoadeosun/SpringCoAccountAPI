namespace SpringCoAccountAPI.Models
{
    public class Piggy
    {
        public Guid PiggyId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double Rate { get; set; }
    }
}
