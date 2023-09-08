using fasito.Models;
using BuyMeACoffeeClone.Data;
using System.Threading.Tasks;

namespace fasito.Services
{
    public class DonationService : IDonationService
    {
        private readonly AppDbContext _context;

        public DonationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDonation(Donation donation)
        {
            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donation>> GetDonationsAsync()
        {
            return await _context.Donations.ToListAsync();
        }

        public async Task<Result> AddDonationAsync(Donation donation)
        {
            if (donation.Amount <= 0)
            {
                return Result.Fail("Donation amount must be greater than zero.");
            }

            try
            {
                _context.Donations.Add(donation);
                await _context.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Failed to create donation: {ex.Message}");
            }
        }

        public async Task SendDonationConfirmationEmailAsync(Donation donation, string userEmail)
            {
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
