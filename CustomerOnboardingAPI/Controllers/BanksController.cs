using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerOnboardingAPI.Models;
using CustomerOnboardingAPI.Services;

namespace CustomerOnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly BankService _bankService;

        public BanksController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bank>>> GetBanks()
        {
            var banks = await _bankService.GetBanksAsync();
            return Ok(banks);
        }
    }
}
