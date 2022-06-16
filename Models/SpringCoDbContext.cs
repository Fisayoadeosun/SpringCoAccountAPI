using SpringCoAccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SpringCoAccountAPI.Models
{
    public class SpringCoDbContext : DbContext
    {
        public SpringCoDbContext(DbContextOptions<SpringCoDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Flex> Flex { get; set; }
        public virtual DbSet<Viva> Viva { get; set; }
        public virtual DbSet<Piggy> Piggy { get; set; }
        public virtual DbSet<Deluxe> Deluxe { get; set; }
        public virtual DbSet<Supa> Supa { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
    }
}