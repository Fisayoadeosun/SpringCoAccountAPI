using System.ComponentModel.DataAnnotations;

namespace SpringCoAccountAPI.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public float Rate { get; set; }

    }
}