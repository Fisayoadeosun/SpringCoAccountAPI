namespace SpringCoAccountAPI.Models
{
    public class CreateAccountDTO
    {
        public string ProductType { get; set; }
        public decimal Rate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
