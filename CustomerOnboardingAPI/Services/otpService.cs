using System;

namespace CustomerOnboardingAPI.Services
{
    public class OtpService
    {
        public string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public void SendOtp(string phoneNumber, string otp)
        {
            // Mock sending OTP
            Console.WriteLine($"Sending OTP {otp} to {phoneNumber}");
        }
    }
}
