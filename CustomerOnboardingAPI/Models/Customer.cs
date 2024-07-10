using System.ComponentModel.DataAnnotations;

namespace CustomerOnboardingAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string StateOfResidence { get; set; }

        [Required]
        public string Lga { get; set; }

        public bool IsVerified { get; set; }
    }
}
