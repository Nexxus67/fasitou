using fasito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fasito.Services
{

  public interface IDonationReportService
    {
        Task<DonationSummary> GetMonthlyDonationSummaryAsync(DateTime month);
        Task<List<DonationDetail>> GetDetailedDonationsAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<string, double>> GetCategoryWiseDonationAsync();
    }

    public class DonationReportService : IDonationReportService
    {
        private readonly IDonationService _donationService;

        public DonationReportService(IDonationService donationService)
        {
            _donationService = donationService;
        }
        public async Task<DonationSummary> GetMonthlyDonationSummaryAsync(DateTime month)
        {
            var donations = await _donationService.GetDonationsAsync();
            var monthlyDonations = donations.Where(d => d.Date.Month == month.Month && d.Date.Year == month.Year);

            var summary = new DonationSummary
            {
                TotalDonors = monthlyDonations.Count(),
                TotalAmount = (double)monthlyDonations.Sum(d => d.Amount),
                AverageDonation = (double)monthlyDonations.Average(d => d.Amount)
            };

            return summary;
        }

        public async Task<List<DonationDetail>> GetDetailedDonationsAsync(DateTime startDate, DateTime endDate)
            {
                var donations = await _donationService.GetDonationsAsync();
                return donations.Where(d => d.Date >= startDate && d.Date <= endDate)
                                .Select(d => new DonationDetail 
                                {
                                   
                                    Date = d.Date,
                                    Amount = d.Amount
                                })
                                .ToList();
            }

      public async Task<Dictionary<string, double>> GetCategoryWiseDonationAsync()
            {
                var donations = await _donationService.GetDonationsAsync();
                return donations.GroupBy(d => d.Category)
                                .ToDictionary(group => group.Key, group => (double)group.Sum(d => d.Amount));
            }
    }

    public class DonationSummary
    {
        public int TotalDonors { get; set; }
        public double TotalAmount { get; set; }
        public double AverageDonation { get; set; }
    }

    public class DonationDetail : Donation
    {
  
    }
}
