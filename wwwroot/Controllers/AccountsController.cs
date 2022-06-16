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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SpringCoDbContext _context;

        public AccountsController(SpringCoDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            if (_context.Account == null)
            {
                return NotFound();
            }
            return await _context.Account.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
            if (_context.Account == null)
            {
                return NotFound();
            }
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(Guid id, Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(CreateAccountDTO account)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'SpringCoDbContext.Account'  is null.");
            }
            var Newaccount = new Account
            {
                ProductType = account.ProductType,
                Rate = account.Rate,
                Created = account.CreatedAt
            };
            _context.Account.Add(Newaccount);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAccount", new { Type = account.ProductType }, account);
            return Ok(new { type = account.ProductType, status = 200 });
        }

        [Route("CreditAccount")]
        [HttpPost]
        public ActionResult<Account> CreditAccount(FundCustomerAccountDTO account)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'SpringCoDbContext.Account'  is null.");
            }
            var getAccountToCredit = _context.Account.Where(c => c.ProductType == account.AccountType.ToLower().Trim()).FirstOrDefault();

            if (getAccountToCredit != null)
            {
                var getCustomer = _context.Customer.Where(c => c.CustomerId == account.CustomerId).FirstOrDefault();
                //var getAccountDetails = _context.Account.Where(c => c.AccountId == account.CustomerId).FirstOrDefault();

                //if (getAccountDetails != null)
                //{
                //    var creditCustomerAccount = FundAccount(getAccountToCredit, getAccountDetails);

                //    if (creditCustomerAccount == "account credited successfully")
                //    {
                //        return Ok(new { status = 200, message = creditCustomerAccount });
                //    }
                //}
                if (getCustomer != null)
                {
                    var creditAccount = FundCustomerAccount(getCustomer, getAccountToCredit, account.DepositAmount);
                    return Ok(new { status = 200, message = "Funding Successful" });
                }
            }
            return BadRequest();
        }
        
        private string FundCustomerAccount(Customer customer, Account account, decimal amount)
        {
            var response = string.Empty;
            var referenceId = new Random();

            if (account.ProductType.ToLower() == "piggy")
            {
                // credit piggy account
                var creditPiggy = new Piggy
                {
                    CustomerId = customer.CustomerId,
                    Balance = amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Piggy.Add(creditPiggy);
                _context.SaveChanges();
                // credit customer
                customer.Balance += amount;
                    _context.Update(customer);
                    _context.SaveChanges();
                    // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Funding",
                    TransactionStatus = "Successful",
                    TransactionType = "Credit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "flex")
            {
                // credit flex account
                var creditFlex = new Flex
                {
                    CustomerId = customer.CustomerId,
                    Balance = amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Flex.Add(creditFlex);
                _context.SaveChanges();
                // credit customer
                customer.Balance += amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Funding",
                    TransactionStatus = "Successful",
                    TransactionType = "Credit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "viva")
            {
                // credit viva account
                var creditViva = new Viva
                {
                    CustomerId = customer.CustomerId,
                    Balance = amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Viva.Add(creditViva);
                _context.SaveChanges();
                // credit customer
                customer.Balance += amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Funding",
                    TransactionStatus = "Successful",
                    TransactionType = "Credit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "supa")
            {
                // credit supa account
                var creditSupa = new Supa
                {
                    CustomerId = customer.CustomerId,
                    Balance = amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Supa.Add(creditSupa);
                _context.SaveChanges();
                // credit customer
                customer.Balance += amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Funding",
                    TransactionStatus = "Successful",
                    TransactionType = "Credit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "deluxe")
            {
                // credit deluxe account
                var creditDeluxe = new Deluxe
                {
                    CustomerId = customer.CustomerId,
                    Balance = amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Deluxe.Add(creditDeluxe);
                _context.SaveChanges();
                // credit customer
                customer.Balance += amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Funding",
                    TransactionStatus = "Successful",
                    TransactionType = "Credit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            return response;
        }

        [Route("DebitAccount")]
        [HttpPost]
        public ActionResult<Account> DebitAccount(DebitCustomerAccountDTO account)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'SpringCoDbContext.Account'  is null.");
            }
            var getAccountToDebit = _context.Account.Where(c => c.ProductType == account.AccountType.ToLower().Trim()).FirstOrDefault();

            if (getAccountToDebit != null)
            {
                var getCustomer = _context.Customer.Where(c => c.CustomerId == account.CustomerId).FirstOrDefault();

                if (getCustomer != null)
                {
                    var debitAccount = DebitCustomerAccount(getCustomer, getAccountToDebit, account.DebitAmount);
                    return Ok(new { status = 200, message = "Account Debited Successfully" });
                }
            }
            return BadRequest();
        }

        private string DebitCustomerAccount(Customer customer, Account account, decimal amount)
        {
            var response = string.Empty;
            var referenceId = new Random();

            if (account.ProductType.ToLower() == "piggy")
            {
                // debit piggy account
                var debitPiggy = new Piggy
                {
                    CustomerId = customer.CustomerId,
                    Balance = -amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Piggy.Add(debitPiggy);
                _context.SaveChanges();
                // debit customer
                customer.Balance -= amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = -amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Debiting",
                    TransactionStatus = "Successful",
                    TransactionType = "Debit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "flex")
            {
                // debit flex account
                var debitFlex = new Flex
                {
                    CustomerId = customer.CustomerId,
                    Balance = -amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Flex.Add(debitFlex);
                _context.SaveChanges();
                // debit customer
                customer.Balance -= amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = -amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Debiting",
                    TransactionStatus = "Successful",
                    TransactionType = "Debit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "viva")
            {
                // debit viva account
                var debitViva = new Viva
                {
                    CustomerId = customer.CustomerId,
                    Balance = -amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Viva.Add(debitViva);
                _context.SaveChanges();
                // debit customer
                customer.Balance -= amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = -amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Debiting",
                    TransactionStatus = "Successful",
                    TransactionType = "Debit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "supa")
            {
                // debit supa account
                var debitSupa = new Supa
                {
                    CustomerId = customer.CustomerId,
                    Balance = -amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Supa.Add(debitSupa);
                _context.SaveChanges();
                // debit customer
                customer.Balance -= amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = -amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Debiting",
                    TransactionStatus = "Successful",
                    TransactionType = "Debit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            if (account.ProductType.ToLower() == "deluxe")
            {
                // debit deluxe account
                var debitDeluxe = new Deluxe
                {
                    CustomerId = customer.CustomerId,
                    Balance = -amount,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Rate = (double)account.Rate
                };
                _context.Deluxe.Add(debitDeluxe);
                _context.SaveChanges();
                // debit customer
                customer.Balance -= amount;
                _context.Update(customer);
                _context.SaveChanges();
                // create transaction history
                var transactionHistory = new Transaction
                {
                    Amount = -amount,
                    CreatedAt = DateTime.Now,
                    CustomerId = customer.CustomerId,
                    RefrenceId = referenceId.Next().ToString(),
                    Purpose = "Debiting",
                    TransactionStatus = "Successful",
                    TransactionType = "Debit",
                    UpdatedAt = DateTime.Now
                };
                _context.Transaction.Add(transactionHistory);
                _context.SaveChanges();
            }

            return response;
        }

        [Route("CreateCustomerAccount")]
        [HttpPost]
        public ActionResult<Account> CreateCustomerAccount(CreateCustomerAccountDTO account)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'SpringCoDbContext.Account'  is null.");
            }
            var getAccountTypeInfo = _context.Account.Where(c => c.ProductType == account.AccountType.ToLower().Trim()).FirstOrDefault();

            if (getAccountTypeInfo != null)
            {

                var getCustomer = _context.Customer.Where(c => c.CustomerId == account.CustomerId).FirstOrDefault();

                if (getCustomer != null)
                {

                    // add customer to a particular account
                    var addCustomerToAnAccount = AddCustomerToAccount(getAccountTypeInfo, getCustomer);

                    if (addCustomerToAnAccount == "account created successfully")
                    {
                        return Ok(new { status = 200, message = addCustomerToAnAccount });
                    }

                }
            }
            return BadRequest();
        }

        private string AddCustomerToAccount(Account account, Customer getCustomer)
        {
            var response = string.Empty;

            if (account.ProductType.ToLower() == "piggy")
            {

                response = CreatePiggyAccount(getCustomer, account);
            }

            else if (account.ProductType.ToLower() == "supa")
            {

                response = CreateSupaAccount(getCustomer, account);
            }

            else if (account.ProductType.ToLower() == "viva")
            {

                response = CreateVivaAccount(getCustomer, account);
            }
            else if (account.ProductType.ToLower() == "Deluxe")
            {
                response = CreateDeluxeAccount(getCustomer, account);
            }
            else if (account.ProductType.ToLower() == "Flex")
            {
                response = CreateFlexAccount(getCustomer, account);
            }

            return response;
        }

        private string CreateFlexAccount(Customer getCustomer, Account account)
        {
            var response = string.Empty;

            var flex = new Flex
            {
                CustomerId = getCustomer.CustomerId,
                CreatedAt = DateTime.Now,
                Balance = getCustomer.Balance,
                Rate = (double)account.Rate
            };
            _context.Flex.Add(flex);
            var save = _context.SaveChanges();

            if (save.ToString() != null)
            {
                response = "account created successfully";
            }

            return response;
        }

        private string CreateDeluxeAccount(Customer getCustomer, Account account)
        {
            var response = string.Empty;

            var deluxe = new Deluxe
            {
                CustomerId = getCustomer.CustomerId,
                CreatedAt = DateTime.Now,
                Balance = getCustomer.Balance,
                Rate = (double)account.Rate
            };
            _context.Deluxe.Add(deluxe);
            var save = _context.SaveChanges();

            if (save.ToString() != null)
            {
                response = "account created successfully";
            }

            return response;
        }

        private string CreateVivaAccount(Customer getCustomer, Account account)
        {
            var response = string.Empty;

            var viva = new Viva
            {
                CustomerId = getCustomer.CustomerId,
                CreatedAt = DateTime.Now,
                Balance = getCustomer.Balance,
                Rate = (double)account.Rate
            };
            _context.Viva.Add(viva);
            var save = _context.SaveChanges();

            if (save.ToString() != null)
            {
                response = "account created successfully";
            }

            return response;
        }

        private string CreateSupaAccount(Customer getCustomer, Account account)
        {
            var response = string.Empty;

            var supa = new Supa
            {
                CustomerId = getCustomer.CustomerId,
                CreatedAt = DateTime.Now,
                Balance = getCustomer.Balance,
                Rate = (double)account.Rate
            };
            _context.Supa.Add(supa);
            var save = _context.SaveChanges();

            if(save.ToString() != null)
            {
                response = "account created successfully";
            }

            return response;
        }

        private string CreatePiggyAccount(Customer getCustomer, Account account)
        {
            var response = string.Empty;

            var piggy = new Piggy
            {
                CustomerId = getCustomer.CustomerId,
                CreatedAt = DateTime.Now,
                 Balance = getCustomer.Balance,
                  Rate = (double)account.Rate
            };
                 _context.Piggy.Add(piggy);
                var saved = _context.SaveChanges();

            if (saved.ToString() != null)
            {
                response = "account created successfully";
            }

            return response;
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Account == null)
            {
                return NotFound();
            }
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(Guid id)
        {
            return (_context.Account?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
