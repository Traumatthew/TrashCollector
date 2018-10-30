using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            List<Customers> customers = new List<Customers>();
            customers = db.Customers.ToList();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = db.Customers.Where(c => c.CustomerId == id).First();
            return View(customerDetails);
        }

        //POST: Customers/Details
        [HttpPost]
        public ActionResult Details(Customers customer, int id)
        {
            Customers customerDetails = db.Customers.Where(c => c.CustomerId == customer.CustomerId).Single();
            return RedirectToAction("Index");
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customers customer = new Customers();
            return View(customer);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Address,AccountBalance")] Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var editCustomer = db.Customers.Where(c => c.CustomerId == id).First();
            return View(editCustomer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,Email,Address")] Customers customers)
        {
            try
            {
                var editCustomer = db.Customers.Where(c => customers.CustomerId == customers.CustomerId).FirstOrDefault();
                editCustomer.FirstName = customers.FirstName;
                editCustomer.LastName = customers.LastName;
                editCustomer.ApplicationUser = customers.ApplicationUser;
                editCustomer.Address = customers.Address;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Customers deleteCustomer = db.Customers.Where(c => c.CustomerId == id).Single();
                db.Customers.Remove(deleteCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
