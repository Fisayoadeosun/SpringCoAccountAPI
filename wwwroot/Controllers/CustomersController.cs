using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpringCoAccountAPI.Models;

namespace SpringCoAccountAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SpringCoDbContext _context;

        public CustomersController(SpringCoDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [Route("api/customers/GetCustomers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
          if (_context.Customer == null)
          {
              return NotFound();
          }
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Customers/5
        [Route("api/customers/GetCustomer/{id}")]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
          if (_context.Customer == null)
          {
              return NotFound();
          }
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("api/customers/UpdateCustomer/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Route("api/customers/PostCustomer")]
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerDTO customer)
        {
          if (_context.Customer == null)
          {
              return Problem("Entity set 'SpringCoDbContext.Customer'  is null.");
          }

            var cust = new Customer
            {
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Created = DateTime.Now,
                EmailAddress = customer.EmailAddress,
                MobileNo = customer.MobileNo,
                Active = customer.Active,
            };
            _context.Customer.Add(cust);
            await _context.SaveChangesAsync();

            var flex = new Flex 
            { CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now, 
                Balance = 0.00m, Rate = 2.5, 
                CustomerId = cust.CustomerId 
            };
            _context.Flex.Add(flex);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { status = 200 }, customer);
        }

        [Route("api/customers/CreateCustomerDetails/{CustomerId}")]
        [HttpGet]
        public ActionResult CreateCustomerDetails(Guid CustomerId)
        {
            var getBalance = GetAllAccountsBalance(CustomerId);
            var split = getBalance.Split();
            var piggyBalance = split[0];
            var flexBalance = split[1];
            var vivaBalance = split[2];
            var supaBalance = split[3];
            var deluxeBalance = split[4];
            var totalAmount = split[5];

            return Ok(new { status = 200, data = new { flexAccountBalance = flexBalance, piggyAccountBalance = piggyBalance, 
                                                        vivaAccountBalance = vivaBalance, supaAccountBalance = supaBalance, 
                                                        deluxeAccountBalance = deluxeBalance  }
        });
        }
        private string GetAllAccountsBalance(Guid CustomerId)
        {
            var sum = 0.0m;
            var sumFlexBalance = 0.0m;
            var sumPiggyBalance = 0.0m;
            var sumVivaBalance = 0.0m;
            var sumSupaBalance = 0.0m;
            var sumDeluxeBalance = 0.0m;


            var getFlexBalance = _context.Flex.Where(c => c.CustomerId == CustomerId).ToList();

            if (getFlexBalance != null)
            {
                foreach (var balance in getFlexBalance)
                {

                    sumFlexBalance += balance.Balance;
                }
            }

            var getPiggyBalance = _context.Piggy.Where(c => c.CustomerId == CustomerId).ToList();

            if (getPiggyBalance != null)
            {

                foreach (var balance in getPiggyBalance)
                {
                    sumPiggyBalance += balance.Balance;
                }
            }

            var getVivaBalance =_context.Viva.Where(c => c.CustomerId == CustomerId).ToList();

            if (getVivaBalance != null)
            {
                foreach(var balance in getVivaBalance)
                {
                    sumVivaBalance += balance.Balance;
                }
            }

            var getSupaBalance = _context.Supa.Where(c => c.CustomerId == CustomerId).ToList();

            if (getSupaBalance != null)
            {
                foreach (var balance in getSupaBalance)
                {
                    sumSupaBalance += balance.Balance;
                }
            }

            var getDeluxeBalance =_context.Deluxe.Where(c => c.CustomerId == CustomerId).ToList();

            if (getDeluxeBalance != null)
            {
                foreach (var balance in getDeluxeBalance)
                {
                    sumDeluxeBalance += balance.Balance;
                }
            }

            var totalAmount = sumPiggyBalance + sumFlexBalance + sumVivaBalance + sumSupaBalance + sumDeluxeBalance;

            return $"{sumPiggyBalance} {sumFlexBalance} {sumVivaBalance} {sumSupaBalance} {sumDeluxeBalance} {totalAmount}";
        }
        // DELETE: api/Customers/5
        [Route("api/customers/DeleteCustomer/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            var customerId = await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(Guid id)
        {
            return (_context.Customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
