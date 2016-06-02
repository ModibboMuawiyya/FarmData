using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmData.Models
{
    public class Processor
    {

        [Key]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string POBox { get; set; }
        public int Fax { get; set; }
        public string Website { get; set; }

        public ICollection<Processor> Processors { get; set; }
        public ICollection<ProcessorContact> ProcessorContacts { get; set; }
        public ICollection<ProductProcessor> ProductProcessors { get; set; }
        public ICollection<ProcessorBusiness> ProcessorBusinesses { get; set; }
        public ICollection<ProcessorPayment> ProcessorPayments { get; set; }
    }
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Display(Name = "FirstName")]
        public string Fname { get; set; }
        [Display(Name = "LastName")]
        public string Lname { get; set; }
        [Display(Name = "MiddleName")]
        public string Mname { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Role { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegDate { get; set; }

        public ICollection<Contact> Contacts { get; set; }
        public ICollection<ProcessorContact> ProcessorContacts { get; set; }

    }

    public class BusinessType
    {
        [Key]
        public int BusinessId { get; set; }
        public string BusType { get; set; }

        public ICollection<BusinessType> BusinessTypes { get; set; }
        public ICollection<ProcessorBusiness> ProcessorBusinesses { get; set; }
    }

    public class LookUPProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }

        public ICollection<LookUPProduct> LookUPProducts { get; set; }
        public ICollection<ProductProcessor> ProductProcessors { get; set; }
    }

    public class ProcessorContact
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyId { get; set; }
        public Processor Processor { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }

    public class ProductProcessor
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyId { get; set; }
        public Processor Processor { get; set; }

        [Key]
        [Column(Order =2)]
        public int ProductId { get; set; }
        public LookUPProduct LookUPProduct { get; set; }
    }

    public class ProcessorBusiness
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyId { get; set; }
        public Processor Processor { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BusinessId { get; set; }
        public BusinessType BusinessType { get; set; }
    }

    public class ProcessorPayment
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyId { get; set; }
        public Processor Processor { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

    }
}
