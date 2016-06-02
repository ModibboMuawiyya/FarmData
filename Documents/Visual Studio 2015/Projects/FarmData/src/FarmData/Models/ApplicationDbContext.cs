﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using FarmData.Models;

namespace FarmData.Models
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
            builder.Entity<ProcessorPayment>().HasKey(d => new { d.CompanyId, d.PaymentId });
            builder.Entity<ProcessorContact>().HasKey(c => new { c.CompanyId, c.ContactId });
            builder.Entity<ProcessorBusiness>().HasKey(b => new { b.CompanyId, b.BusinessId });
            builder.Entity<ProductProcessor>().HasKey(e => new { e.CompanyId, e.ProductId });
        }
        public DbSet<Farmer> Farmer { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Cluster> Cluster { get; set; }
        public DbSet<ClusterFarmer> ClusterFarmer { get; set; }
        public DbSet<Cooperatives> Cooperatives { get; set; }
        public DbSet<FarmDetail> FarmDetail { get; set; }
        public DbSet<Farmer_Payment> Farmer_Payment { get; set; }
        public DbSet<FarmType> FarmType { get; set; }
        public DbSet<Processor> Processor { get; set; }
        public DbSet<ProcessorBusiness> ProcessorBusiness { get; set; }
        public DbSet<LookUPProduct> LookUPProduct { get; set; }
        public DbSet<ProcessorContact> ProcessorContact { get; set; }
        public DbSet<ProcessorPayment> ProcessorPayment { get; set; }
        public DbSet<ProductProcessor> ProductProcessor { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<BusinessType> BusinessType { get; set; }
    }
}