using fasito.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyMeACoffeeClone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Donation> Donations { get; set; }
    }
}
