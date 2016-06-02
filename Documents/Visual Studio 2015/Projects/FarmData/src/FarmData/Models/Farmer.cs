using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FarmData.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int RegDate { get; set; }


        public ICollection<Child> Children { get; set; }
        public ICollection<FarmDetail> Farms { get; set; }
        public ICollection<Cluster> Clusters { get; set; }
        public ICollection<Farmer_Payment> FarmerPayments { get; set; }
        public ICollection<ClusterFarmer> ClusterFarmers { get; set; }
    }

    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        //Foreign Key for Farmer
        public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }

    }

    public class FarmDetail
    {
        [Key]
        public int FarmId { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public string ProductionTime { get; set; }
        public string Practice { get; set; }
        public int Size { get; set; }

        public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }
    }

    public class BioData
    {
        [Key]
        public int FarmerId { get; set; }
        public byte[] FarmerPic { get; set; }
        public byte[] Signature { get; set; }
        public byte[] FingerPrint { get; set; }
        public DateTime EntryDate { get; set; }
    }

    public class Farmer_Payment
    {
        [Key]
        [Column(Order = 1)]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }

    public class Cluster
    {
        [Key]
        public int ClusterId { get; set; }
        [Display(Name = "Leader Name")]
        public string Leader { get; set; }
        public int NumberOfFarmers { get; set; }


        public Farmer Farmer { get; set; }
        public int FarmerId { get; set; }

        public ICollection<Cluster> Clusters { get; set; }
        public ICollection<ClusterFarmer> ClusterFarmers { get; set; }
    }

    public class Cooperatives
    {
        [Key]
        public int CooperativeId { get; set; }
        public int ClusterNumber { get; set; }

        public int ClusterId { get; set; }
        public Cluster Cluster { get; set; }
    }

    public class ClusterFarmer
    {
        [Key]
        [Column(Order = 1)]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ClusterId { get; set; }
        public Cluster Cluster { get; set; }
    }

    public class FarmType
    {
        [Key]
        public int FarmTypeId { get; set; }
        public string Type { get; set; }
    }
}
