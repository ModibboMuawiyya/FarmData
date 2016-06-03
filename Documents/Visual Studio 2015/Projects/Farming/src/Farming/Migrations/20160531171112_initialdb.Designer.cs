using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Farming.Models;

namespace Farming.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160531171112_initialdb")]
    partial class initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Farming.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Farming.Models.BioData", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EntryDate");

                    b.Property<byte[]>("FarmerPic");

                    b.Property<byte[]>("FingerPrint");

                    b.Property<byte[]>("Signature");

                    b.HasKey("FarmerId");
                });

            modelBuilder.Entity("Farming.Models.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DoB");

                    b.Property<int>("FarmerId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("ChildId");
                });

            modelBuilder.Entity("Farming.Models.Cluster", b =>
                {
                    b.Property<int>("ClusterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClusterClusterId");

                    b.Property<int>("FarmerId");

                    b.Property<string>("Leader");

                    b.Property<int>("NumberOfFarmers");

                    b.HasKey("ClusterId");
                });

            modelBuilder.Entity("Farming.Models.ClusterFarmer", b =>
                {
                    b.Property<int>("FarmerId");

                    b.Property<int>("ClusterId");

                    b.Property<int?>("ClusterClusterId");

                    b.Property<int?>("FarmerFarmerId");

                    b.HasKey("FarmerId", "ClusterId");
                });

            modelBuilder.Entity("Farming.Models.Cooperatives", b =>
                {
                    b.Property<int>("CooperativeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClusterId");

                    b.Property<int>("ClusterNumber");

                    b.HasKey("CooperativeId");
                });

            modelBuilder.Entity("Farming.Models.FarmDetail", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FarmerId");

                    b.Property<string>("Location");

                    b.Property<string>("Practice");

                    b.Property<string>("ProductionTime");

                    b.Property<int>("Quantity");

                    b.Property<int>("Size");

                    b.HasKey("FarmId");
                });

            modelBuilder.Entity("Farming.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("DoB");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("OtherName");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("RegDate");

                    b.HasKey("FarmerId");
                });

            modelBuilder.Entity("Farming.Models.Farmer_Payment", b =>
                {
                    b.Property<int>("FarmerId");

                    b.Property<int>("PaymentId");

                    b.Property<int?>("FarmerFarmerId");

                    b.Property<int?>("PaymentPaymentId");

                    b.HasKey("FarmerId", "PaymentId");
                });

            modelBuilder.Entity("Farming.Models.FarmType", b =>
                {
                    b.Property<int>("FarmTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("FarmTypeId");
                });

            modelBuilder.Entity("Farming.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankDetails");

                    b.Property<string>("CardDetails");

                    b.Property<string>("OtherDetails");

                    b.Property<int>("PaymentCode");

                    b.HasKey("PaymentId");
                });

            modelBuilder.Entity("Farming.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PaymentDescription");

                    b.HasKey("PaymentCode");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Farming.Models.Child", b =>
                {
                    b.HasOne("Farming.Models.Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId");
                });

            modelBuilder.Entity("Farming.Models.Cluster", b =>
                {
                    b.HasOne("Farming.Models.Cluster")
                        .WithMany()
                        .HasForeignKey("ClusterClusterId");

                    b.HasOne("Farming.Models.Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId");
                });

            modelBuilder.Entity("Farming.Models.ClusterFarmer", b =>
                {
                    b.HasOne("Farming.Models.Cluster")
                        .WithMany()
                        .HasForeignKey("ClusterClusterId");

                    b.HasOne("Farming.Models.Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerFarmerId");
                });

            modelBuilder.Entity("Farming.Models.Cooperatives", b =>
                {
                    b.HasOne("Farming.Models.Cluster")
                        .WithMany()
                        .HasForeignKey("ClusterId");
                });

            modelBuilder.Entity("Farming.Models.FarmDetail", b =>
                {
                    b.HasOne("Farming.Models.Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerId");
                });

            modelBuilder.Entity("Farming.Models.Farmer_Payment", b =>
                {
                    b.HasOne("Farming.Models.Farmer")
                        .WithMany()
                        .HasForeignKey("FarmerFarmerId");

                    b.HasOne("Farming.Models.Payment")
                        .WithMany()
                        .HasForeignKey("PaymentPaymentId");
                });

            modelBuilder.Entity("Farming.Models.Payment", b =>
                {
                    b.HasOne("Farming.Models.PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentCode");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Farming.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Farming.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Farming.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
