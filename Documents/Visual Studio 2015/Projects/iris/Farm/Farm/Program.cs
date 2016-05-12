using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
   public partial class Profile
    {
        public Profile()
        {

        }
        [Key]
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string OtherName { get; set; }
        //public string Gender { get; set; }
        //public DateTime DoB { get; set; }
        //public int PhoneNumber { get; set; }
        //public string Address { get; set; }
        //public DateTime RegDate { get; set;}

        //public virtual Child Child { get; set; }
        public virtual BioData BioData { get; set; }
        //public virtual FarmDetail FarmDetail { get; set; }
        //public virtual Cluster2Farmer Cluster2Farmer { get; set; }
    }

    public partial class BioData
    {
        public BioData()
        {

        }
        public int FarmerId { get; set; }
        public byte[] Picture { get; set; }
        //public byte[] Signateure { get; set; }
        //public byte[] Fingerprint { get; set; }
        //public DateTime EntryDate { get; set; }

        public virtual Profile Profile { get; set; }
    }

    //public partial class Child
    // {
    //     public Child()
    //     {
    //         Profiles = new List<Profile>();
    //     } 

    //     public int ChildId { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public string Gender { get; set; }
    //     public DateTime DoB { get; set; }
    //     public int PhoneNumber { get; set; }
    //     public string Address { get; set; }

    //     public virtual ICollection<Profile> Profiles { get; set; }
    // }

    //public partial class FarmDetail
    // {
    //     public FarmDetail()
    //     {

    //     }

    //     public int FarmId { get; set; }
    //     public string Location { get; set; }
    //     public int Quantity { get; set; }
    //     public DateTime ToP { get; set; }
    //     public string Practices { get; set; }
    //     public int Size { get; set; }
    //     public string Cluster { get; set; }

    //     public virtual ICollection<Profile> Profiles { get; set; }
    // }

    //public partial class Payment
    // {
    //     public Payment()
    //     {

    //     }

    //     public int PaymentId { get; set; }
    //     public string BankDetails { get; set; }
    //     public string CardDetails { get; set; }
    //     public string OtherDetails { get; set; }


    // }

    //public class Farmer2Payment
    // {
    //     [Key]
    //     [Column(Order =0)]
    //     public int FarmerId { get; set; }

    //     [Key]
    //     [Column(Order =1)]
    //     public int PaymentId { get; set; }


    // }

    //public class Cluster2Farmer
    // {
    //     [Key]
    //     [Column(Order =0)]
    //     public int FarmerId { get; set; }

    //     [Key]
    //     [Column(Order =1)]
    //     public int ClusterId { get; set; }

    //     public virtual Profile Profiles { get; set; }
    //     public virtual Cluster Cluster { get; set; }
    // }

    //public partial class PaymentMethod
    // {
    //     public PaymentMethod()
    //     {

    //     }

    //     public int PaymentCode { get; set; }
    //     public string PaymentDescription { get; set;}
    // }

    //public partial class Cluster
    // {
    //     public Cluster()
    //     {

    //     }

    //     public int ClusterId { get; set; }
    //     public string Leader { get; set; }
    //     public int Farmers { get; set; }

    //     public virtual Cluster2Farmer Cluster2Farmer { get; set;}

    // }

    //public partial class Cooperative
    // {
    //     public Cooperative()
    //     {

    //     }

    //     public int CoopId { get; set; }
    //     public int Clusters { get; set; }
    // }

    //public partial class FarmType
    // {
    //     public FarmType()
    //     {

    //     }

    //     public int FarmTypeId { get; set; }
    //     public string Type { get; set; }
    // } 

    public class FarmContext : DbContext
    {
        public FarmContext(): base()
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<BioData> BioDatas { get; set; }
        //public DbSet<Child> Children { get; set; }
        //public DbSet<FarmDetail> FarmDetails { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<PaymentMethod> PaymentMethods { get; set; }
        //public DbSet<Cluster> Clusters { get; set; }
        //public DbSet<Cooperative> Cooperatives { get; set; }
        //public DbSet<FarmType> FarmTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Farm");
            ////one to many between Profile and Child    
            //modelBuilder.Entity<Profile>()
            //            .HasRequired(c => c.Child)
            //            .WithMany(c => c.Profiles);
            ////one to one relationship between BioData and Profile
            //modelBuilder.Entity<BioData>()
            //            .HasKey(e => e.FarmerId);

            //modelBuilder.Entity<BioData>()
            //            .HasRequired(b => b.Profile)
            //            .WithRequiredPrincipal(ad => ad.BioData);
            //////one to many between Profile and FarmDetail    
            //modelBuilder.Entity<Profile>()
            //            .HasRequired(f => f.FarmDetail)
            //            .WithMany(c => c.Profiles);

            //// one to one between Cluster2Farmer and Profile
            //modelBuilder.Entity<Cluster2Farmer>()
            //            .HasKey(p => p.FarmerId);

            //modelBuilder.Entity<Profile>()
            //            .HasRequired(p => p.Cluster2Farmer)
            //            .WithRequiredPrincipal(cf => cf.Profiles);

            //// one to one between Cluster2Farmer and Cluster
            //modelBuilder.Entity<Cluster2Farmer>()
            //            .HasKey(d => d.ClusterId);

            //modelBuilder.Entity<Cluster>()
            //            .HasRequired(d => d.Cluster2Farmer)
            //            .WithRequiredPrincipal(fc => fc.Cluster);

            //// one to one between Cooperative and Cluster
            //modelBuilder.Entity<Cluster2Farmer>()
            //            .HasKey(d => d.ClusterId);

            //modelBuilder.Entity<Cluster>()
            //            .HasRequired(d => d.Cluster2Farmer)
            //            .WithRequiredPrincipal(fc => fc.Cluster);
        }

    }

}
