using fasito.Models;
using System.Threading.Tasks;

namespace fasito.Services
{
    public interface IDonationService
    {
        Task AddDonation(Donation donation);
    }
}
