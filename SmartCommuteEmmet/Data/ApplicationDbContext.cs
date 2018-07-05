using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartCommuteEmmet.Models;

namespace SmartCommuteEmmet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<SmartCommuteEmmet.Models.Commute> Commute { get; set; }

        public DbSet<SmartCommuteEmmet.Models.CommuteType> CommuteType { get; set; }

        public DbSet<SmartCommuteEmmet.Models.Business> Business { get; set; }

        public DbSet<SmartCommuteEmmet.Models.ConfigDate> ConfigDate { get; set; }

        public DbSet<SmartCommuteEmmet.Models.Sponsor> Sponsor { get; set; }

        public DbSet<SmartCommuteEmmet.Models.Breakfast> Breakfast { get; set; }

        public DbSet<SmartCommuteEmmet.Models.Document> Document { get; set; }

        public DbSet<SmartCommuteEmmet.Models.StartPoint> StartPoint { get; set; }

        public DbSet<SmartCommuteEmmet.Models.EndPoint> EndPoint { get; set; }

        public DbSet<SmartCommuteEmmet.Models.Reward> Reward { get; set; }

        public DbSet<SmartCommuteEmmet.Models.CarouselSponsorImage> CarouselSponsorImage { get; set; }
    }
}
