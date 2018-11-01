using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            //List<Customers> customers = new List<Customers>();
            //customers = db.Customers.ToList();
            //return View(customers);
            string currentUserId = User.Identity.GetUserId();

            //ASK ABOUT THIS

            var customer = db.Customers.Where(c => c.ApplicationUserId == currentUserId).FirstOrDefault();
            var customers = db.Customers.Include(c => c.ApplicationUser);


            return View(customer);


        }

        //=============================================================================================================================

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            //var customerDetails = db.Customers.Where(c => c.CustomerId == id).First();
            //return View(customerDetails);

            Customers customerDetails = null;
            if(id == null)
            {
                string currentUserId = User.Identity.GetUserId();
                customerDetails = db.Customers.Where(c => c.ApplicationUserId == currentUserId).FirstOrDefault();
                return View(customerDetails);
            }
            Customers customers = db.Customers.Find(id);

            if(customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);

        }

        //=============================================================================================================================

        //POST: Customers/Details
        //[HttpPost]
        //public ActionResult Details(Customers customer, int id)
        //{
        //    Customers customerDetails = db.Customers.Where(c => c.CustomerId == customer.CustomerId).Single();
        //    return RedirectToAction("Index");
        //}

        //=============================================================================================================================

        // GET: Customers/Create
        public ActionResult Create()
        {
            //Customers customer = new Customers();
            //return View(customer);

            ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationRoleId");
            Customers theCustomers = new Customers();
            Employees theEmployees = new Employees();
            Pickups thePickups = new Pickups();
            Address theAddress = new Address();
            ViewModel viewModel = new ViewModel()
            {
                customers = theCustomers,
                employees = theEmployees,
                pickups = thePickups,
                address = theAddress
            };
            return View(viewModel);

        }

        //=============================================================================================================================
        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(ViewModel viewModel)
        {
            //viewModel.customers.ApplicationUser
            //viewModel.customers.FirstName;
            //viewModel.customers.LastName;
            //viewModel
            if (ModelState.IsValid)
            {
                //Pickups pickups = new Pickups();
                //pickups.ExtraPickUp?
                //    pickups.PickUpCompleted ?
                // get the Id of the currently logged in ApplicationUser
                string currentUserId = User.Identity.GetUserId();
                viewModel.customers.ApplicationUserId = currentUserId;
                //db.Pickups.Add(pickups);
                db.Customers.Add(viewModel.customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserId", viewModel.customers.ApplicationUserId);
            return View(viewModel.customers);

        }
        //// POST: Customers/Create
        //[HttpPost]
        //public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,DatePickUpsStart,DatePickUpsEnd,PickUpDay,ExtraPickUp,PickUpCompleted")] Customers customer)
        //{
        //    //viewModel.customers.ApplicationUser
        //    //viewModel.customers.FirstName;
        //    //viewModel.customers.LastName;
        //    //viewModel
        //    if (ModelState.IsValid)
        //    {
        //        //Pickups pickups = new Pickups();
        //        //pickups.ExtraPickUp?
        //        //    pickups.PickUpCompleted ?
        //        // get the Id of the currently logged in ApplicationUser
        //        string currentUserId = User.Identity.GetUserId();
        //        customer.ApplicationUserId = currentUserId;
        //        //db.Pickups.Add(pickups);
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserId", customer.ApplicationUserId);
        //    return View(customer);
            
        //}

        //=============================================================================================================================

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            //var editCustomer = db.Customers.Where(c => c.CustomerId == id).First();
            //return View(editCustomer);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            //Need To Check
            ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserRoleId", customers.ApplicationUserId);
            return View(customers);
        }

        //=============================================================================================================================

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,Email,Address,DatePickUpsStart,DatePickUpsEnd,PickUpDay,ExtraPickUp,AccountBalance,ApplicationUserId,PickUpCompleted")] Customers customers)
        {
            //var editCustomer = db.Customers.Where(c => customers.CustomerId == customers.CustomerId).FirstOrDefault();
            //editCustomer.FirstName = customers.FirstName;
            //editCustomer.LastName = customers.LastName;
            //editCustomer.ApplicationUserId = customers.ApplicationUserId;
            //editCustomer.Address = customers.Address;
            //db.SaveChanges();
            //return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserId", customers.ApplicationUserId);
            return View(customers);
        }

        //=============================================================================================================================

        //GET: Customers/Delete
        public ActionResult Delete(int? id)
        {
            //Customers deleteCustomer = db.Customers.Where(c => c.CustomerId == id).Single();
            //db.Customers.Remove(deleteCustomer);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        //=============================================================================================================================

        //POST: Customers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        //=============================================================================================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
