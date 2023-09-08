using fasito.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic; // Added for List<T>
using System.Net.Mail;
using System.Net;

namespace fasito.Services
{
    public class DonationService : IDonationService
    {
        // Replacing AppDbContext with a List to mock in-memory data
        private readonly List<Donation> _donations = new List<Donation>();

        // Removing the constructor as we don't need to initialize anything specific

        public async Task AddDonation(Donation donation)
        {
            if (donation == null) throw new ArgumentNullException(nameof(donation));

            _donations.Add(donation);
            await Task.CompletedTask; // Mocks the asynchronous nature of the original SaveChangesAsync method
        }

        public async Task<List<Donation>> GetDonationsAsync()
        {
            // Simulating asynchronous operation
            return await Task.FromResult(_donations);
        }

        public async Task<Result> AddDonationAsync(Donation donation)
        {
            if (donation == null) throw new ArgumentNullException(nameof(donation));
            
            if (donation.Amount <= 0)
            {
                return Result.Fail("Donation amount must be greater than zero.");
            }

            try
            {
                _donations.Add(donation);
                await Task.CompletedTask;
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Failed to create donation: {ex.Message}");
            }
        }

        public async Task SendDonationConfirmationEmailAsync(Donation donation, string userEmail)
        {
            if (donation == null) throw new ArgumentNullException(nameof(donation));

            var smtpClient = new SmtpClient("your-smtp-server.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                EnableSsl = true,
            };

            var message = new MailMessage("your-email@example.com", userEmail)
            {
                Subject = "Donation Confirmation",
                Body = $"Thank you for your donation of ${donation.Amount}.",
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
