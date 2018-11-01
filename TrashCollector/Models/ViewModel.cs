using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class ViewModel
    {
        public Customers customers { get; set; }
        public Employees employees { get; set; }
        public Address address { get; set; }
        public Pickups pickups { get; set; }
    }
}