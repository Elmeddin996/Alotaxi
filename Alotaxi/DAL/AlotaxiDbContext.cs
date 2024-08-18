using Alotaxi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alotaxi.DAL
{
    public class AlotaxiDbContext:IdentityDbContext
    {
        public AlotaxiDbContext(DbContextOptions<AlotaxiDbContext> options) : base(options) { }


        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<WhyUs> WhyUs { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
