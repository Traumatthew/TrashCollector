using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Pickups
    {
        [Key]
        public int PickUpId { get; set; }

        [ForeignKey("Employees")]
        public int? EmployeeId { get; set; }
        public Employees Employees { get; set; }

        //[ForeignKey("Customers")]
        //public int CustomerId { get; set; }
        //public Customers customer { get; set; }

        //[Display(Name = "Pickups Start")]
        //public DateTime? DatePickUpsStart { get; set; }

        //[Display(Name = "Pickups End")]
        //public DateTime? DatePickUpsEnd { get; set; }

        //[Display(Name = "Pickup Day")]
        //public string WeekDay { get; set; }

        [Display(Name = "Extra Pickup")]
        public DateTime? ExtraPickUp { get; set; }


        [Display(Name = "Pick Up Completed")]
        public bool PickUpCompleted { get; set; }

        public double Charge { get; set; }

        [Display(Name = "Pickup Start Date")]
        public DateTime PickUpDate { get; set; }
    }
}