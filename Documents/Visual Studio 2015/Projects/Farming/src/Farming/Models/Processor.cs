using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farming.Models
{
    public class Processor
    {
        public class ProcessorProfile
        {
            [Key]
            public int CompanyId { get; set; }
            [Display(Name ="Company Name")]
            public string Name { get; set; }
            public string Location { get; set; }
            public string POBox { get; set; }
            public int Fax { get; set; }
            public string Website { get; set; }
        }

        public class Contact
        {
            [Key]
            public int ContactId { get; set; }
            [Display(Name = "FirstName")]
            public string Fname { get; set; }
            [Display(Name = "LastName")]
            public string Lname { get; set; }
            [Display(Name ="MiddleName")]

        }
    }
}
