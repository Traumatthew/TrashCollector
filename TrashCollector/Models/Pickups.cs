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

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customers Customers { get; set; }

        [Display(Name = "Start Day")]
        public DateTime? StartDay { get; set; }

        [Display(Name = "End Day")]
        public DateTime? EndDay { get; set; }

        [Display(Name = "Pick Up Day")]
        public DateTime? PickUpDay { get; set; }

        [Display(Name = "Bonus Pick Up Day")]
        public DateTime? BonusPickUp { get; set; }

        [ForeignKey("Employees")]
        public int? EmployeeId { get; set; }
        public Employees Employees { get; set; }
    }
}