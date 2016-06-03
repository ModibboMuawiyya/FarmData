using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Farming.Models;

namespace Farming.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ClusterFarmer>().HasKey(x => new { x.FarmerId, x.ClusterId });
            builder.Entity<Farmer_Payment>().HasKey(p => new { p.FarmerId, p.PaymentId });
                
        }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<FarmDetail> FarmDetail { get; set; }
        public DbSet<Cluster> Cluster { get; set; }
        public DbSet<Cooperatives> Cooperatives { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<BioData> BioData { get; set; }
        public DbSet<FarmType> FarmType { get; set; }
        public DbSet<ClusterFarmer> ClusterFarmer { get; set; }
        public DbSet<Farmer_Payment> Farmer_Payment { get; set; }
    }
}
