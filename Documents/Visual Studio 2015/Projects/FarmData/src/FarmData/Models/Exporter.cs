using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmData.Models
{
    public class Exporter
    {
        [Key]
        public int ExporterId { get; set; }
        public string ExName { get; set; }
        public string Location { get; set; }
        public int Fax { get; set; }
        public string POBox { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string website { get; set; }

        public ICollection<ExporterPayment> ExporterPayments { get; set; }
        public ICollection<AgentExporter> AgentExporters { get; set; }
        public ICollection<ExporterCartegories> ExporterCartegories { get; set; }
    }

    public class Agent
    {
        [Key]
        public int AgentId { get; set; }
        [Display(Name = "LastName")]
        public string LName { get; set; }
        [Display(Name = "FirstName")]
        public string FName { get; set; }
        [Display(Name = "MiddleName")]
        public string MName { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<AgentExporter> AgentExporters { get; set; }
    }

    public class Cartegories
    {
        [Key]
        public int CartegoriesId { get; set; }
        public string CatType { get; set; }

        public ICollection<ExporterCartegories> ExporterCartegories { get; set; }
    }

    public class AgentExporter
    {
        [Key]
        public int ExporterId { get; set; }
        public Exporter Exporter { get; set; }

        [Key]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }

    public class ExporterCartegories
    {
        [Key]
        public int CartegoriesId { get; set; }
        public Cartegories Cartegories { get; set; }

        [Key]
        public int ExporterId { get; set; }
        public Exporter Exporter { get; set; }
    }

    public class ExporterPayment
    {
        [Key]
        public int ExporterId { get; set; }
        public Exporter Exporter { get; set; }

        [Key]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
