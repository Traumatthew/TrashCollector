using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string ZipCode { get; set; }

        //[ForeignKey("Address")]
        //[Display(Name = "Customers To Collect")]
        //public int AddressId { get; set; }
        //public Address Address { get; set; }

        public IEnumerable<Customers> Customers { get; set; }
    }
}