using fasito.Models;
using System.Threading.Tasks;

namespace fasito.Services
{
public interface IDonationService
{
    Task AddDonation(Donation donation);
    Task<List<Donation>> GetDonationsAsync();
    Task<Result> AddDonationAsync(Donation donation);
    Task SendDonationConfirmationEmailAsync(Donation donation, string userEmail);
}
}
