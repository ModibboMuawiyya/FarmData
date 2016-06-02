using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmData.Models
{
    public class NewFarmer
    {
        [Key]
        public int NewId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidlleName { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Training> Trainings { get; set; }
        public ICollection<Qualification> Qualifications { get; set; }
        public ICollection<UserPayment> UserPayments { get; set; }
    }

    public class Training
    {
        [Key]
        public int TrainId { get; set; }
        [Display(Name = "Name of Training")]
        public string TName { get; set; }
        [Display(Name = "Duration")]
        public string TDuration { get; set; }

        public int NewId { get; set; }
        public NewFarmer NewFarmer { get; set; }

    }

    public class Qualification
    {
        [Key]
        public int QuaificationId { get; set; }
        public string QuaificationType { get; set; }

        public int NewId { get; set; }
        public NewFarmer NewFarmer { get; set; }
    }

    public class NewUserBio
    {
        [Key]
        public int NewId { get; set; }
        public byte[] UserPrint { get; set; }
        public byte[] UserPicture { get; set; }
        public byte[] UserSignature { get; set; }
    }

    public class UserPayment
    {
        [Key]
        public int NewId { get; set; }
        public NewFarmer NewFarmer { get; set; }

        [Key]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
