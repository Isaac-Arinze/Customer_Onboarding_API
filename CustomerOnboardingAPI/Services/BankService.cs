using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CustomerOnboardingAPI.Models;

namespace CustomerOnboardingAPI.Services
{
    public class BankService
    {
        private readonly HttpClient _httpClient;

        public BankService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Bank>> GetBanksAsync()
        {
            var response = await _httpClient.GetStringAsync("https://wema-alatdev-apimgt.developer.azure-api.net/api/GetBanks");
            return JsonSerializer.Deserialize<List<Bank>>(response);
        }
    }
}
