using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tracker.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<TrackerUser> TrackerUser { get; set; }
    }
}
