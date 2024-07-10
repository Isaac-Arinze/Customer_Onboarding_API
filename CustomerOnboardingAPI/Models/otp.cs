using System.ComponentModel.DataAnnotations;

namespace CustomerOnboardingAPI.Models
{
    public class Otp
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
