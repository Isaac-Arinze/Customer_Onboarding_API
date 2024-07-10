using System.Collections.Generic;
using System.Linq;
using CustomerOnboardingAPI.Data;
using CustomerOnboardingAPI.Models;

namespace CustomerOnboardingAPI.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomerByPhoneNumber(string phoneNumber)
        {
            return _context.Customers.SingleOrDefault(c => c.PhoneNumber == phoneNumber);
        }

        public void VerifyCustomer(string phoneNumber)
        {
            var customer = GetCustomerByPhoneNumber(phoneNumber);
            if (customer != null)
            {
                customer.IsVerified = true;
                _context.SaveChanges();
            }
        }
    }
}
