using fasito.Models;
using BuyMeACoffeeClone.Data;
using System.Threading.Tasks;

namespace fasito.Services
{
    public class DonationService
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
    }
}
