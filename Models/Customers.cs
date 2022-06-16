using System.ComponentModel.DataAnnotations;

namespace SpringCoAccountAPI.Models
{
    public class Customer
    {
        //public Customer()
        //{
        //    Accounts = new HashSet<Account>();
        //}
        public Guid CustomerId { get; set; }
        //public string? CustomerCode { get; set; }
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
        //public ICollection<Account> Accounts { get; set; }
        public Guid AccountId { get; set; }
        //public Guid PiggyId { get; set; }
        //public int CreatedBy { get; set; }
    }
}