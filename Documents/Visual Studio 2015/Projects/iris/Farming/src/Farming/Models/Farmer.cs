using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Farming.Models
{
    public class Farmer
    {
        public class Profile
        {
            [ScaffoldColumn(false)]
            public int FarmerID { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "First Name")]
            public string FirstMidname { get; set; }
            public string Gender { get; set; }
            public DateTime DoB { get; set; }
            public int PhoneNumber { get; set; }
            public string Address { get; set; }
            public DateTime RegDate { get; set; }

            public virtual ICollection<Child> Children { get; set; }
        }

        public class Child
        {
            [Key]
            public int childID { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "First Name")]
            public string FirstMidName { get; set; }
            public string Gender { get; set; }
            public DateTime DoB { get; set; }
            public int PhoneNumber { get; set; }
            public string Address { get; set; }
            public DateTime RegDate { get; set; }


            public int FarmerID { get; set; }

            public virtual Profile Profile { get; set; }

        }
    }
}
