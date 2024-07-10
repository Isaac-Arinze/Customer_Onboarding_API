using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomerOnboardingAPI.Models;
using CustomerOnboardingAPI.Services;

namespace CustomerOnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly OtpService _otpService;

        public CustomersController(CustomerService customerService, OtpService otpService)
        {
            _customerService = customerService;
            _otpService = otpService;
        }

        [HttpPost("onboard")]
        public IActionResult OnboardCustomer([FromBody] Customer customer)
        {
            if (_customerService.GetCustomerByPhoneNumber(customer.PhoneNumber) != null)
            {
                return BadRequest("Customer with this phone number already exists.");
            }

            string otp = _otpService.GenerateOtp();
            _otpService.SendOtp(customer.PhoneNumber, otp);

            _customerService.AddCustomer(customer);
            return Ok("Customer added. Please verify the OTP sent to your phone.");
        }

        [HttpPost("verify")]
        public IActionResult VerifyCustomer([FromBody] string phoneNumber)
        {
            _customerService.VerifyCustomer(phoneNumber);
            return Ok("Customer verified.");
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }
    }
}
