using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "Choose 'Employee' or 'Customer'")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Pickups")]
        public int PickId { get; set; }
        public Pickups Pickups { get; set; }


        //[Display(Name = "Pickups Start")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:mm-dd-yy}", ApplyFormatInEditMode = true)]
        //public DateTime? DatePickUpsStart { get; set; }

        //[Display(Name = "Pickups End")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:mm-dd-yy}", ApplyFormatInEditMode = true)]
        //public DateTime? DatePickUpsEnd { get; set; }

        //[Display(Name = "Pickup Day")]
        //public DayOfWeek PickUpDay { get; set; }

        //[Display(Name = "Extra Pickup")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:mm-dd-yy}", ApplyFormatInEditMode = true)]
        //public DateTime? ExtraPickUp { get; set; }

        [Display(Name = "Account Balance")]
        public decimal AccountBalance { get; set; }
    }
}