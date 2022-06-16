using System.ComponentModel.DataAnnotations;

namespace SpringCoAccountAPI.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        //public Guid? CustomerId { get; set; }
        //public Customer? Customer { get; set; }
        public string ProductType { get; set; }
        public decimal Rate { get; set; }
        //public decimal AccountBalance { get; set; }
        //public decimal PreviousBalance { get; set; }
        //public bool Active { get; set; }
        public DateTime Created { get; set; }
        //public DateTime Updated { get; set; }
        //public DateTime Deleted { get; set; }
    }
}