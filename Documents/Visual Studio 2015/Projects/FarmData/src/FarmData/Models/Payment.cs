using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmData.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string BankDetails { get; set; }
        public string CardDetails { get; set; }
        public string OtherDetails { get; set; }

        public int PaymentCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<Farmer_Payment> FarmerPayments { get; set; }
        public ICollection<ProcessorPayment> ProcessorPayments { get; set; }
    }

    public class PaymentMethod
    {
        [Key]
        public int PaymentCode { get; set; }
        public string PaymentDescription { get; set; }

        public ICollection<Payment> Payments { get; set; }

    }
}
