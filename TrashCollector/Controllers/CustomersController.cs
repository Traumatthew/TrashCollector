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
            var currentUserId = User.Identity.GetUserId();

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
            /*Customers customerDetails = null*/
            ViewModel viewModel = new ViewModel();

            if(id == null)
            {
                //string currentUserId = User.Identity.GetUserId();
                //customerDetails = db.Customers.Where(c => c.ApplicationUserId == currentUserId).FirstOrDefault();
                //return View(customerDetails);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            viewModel.customers = db.Customers.Find(id);
            viewModel.address = db.Addresses.Find(viewModel.customers.AddressId);
            viewModel.pickups = db.Pickups.Where(p => p.PickUpId == viewModel.customers.PickId).Single();

            if(viewModel.customers == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);

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
        public ActionResult Create(ViewModel viewModel, DateTime? PickUpDay)
        {
            //viewModel.customers.ApplicationUser
            //viewModel.customers.FirstName;
            //viewModel.customers.LastName;
            viewModel.customers.ApplicationUserId = User.Identity.GetUserId();
            viewModel.pickups = new Pickups();
            //pickups.ExtraPickUp?
            //    pickups.PickUpCompleted ?
            viewModel.pickups.PickUpDay =  PickUpDay;
            viewModel.pickups.Charge = 50;
            viewModel.address.AddressId = viewModel.customers.CustomerId;
            

                db.Customers.Add(viewModel.customers);
                db.Addresses.Add(viewModel.address);
                db.Pickups.Add(viewModel.pickups);
                // get the Id of the currently logged in ApplicationUser
                //string currentUserId = User.Identity.GetUserId();
                //viewModel.customers.ApplicationUserId = currentUserId;
                db.SaveChanges();
                return RedirectToAction("Details");

            //ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserId", viewModel.customers.ApplicationUserId);
            //return View(viewModel.customers);

        }

        //=============================================================================================================================

        // GET: Customers/Edit/5
        public ActionResult Edit()
        {
            //var editCustomer = db.Customers.Where(c => c.CustomerId == id).First();
            //return View(editCustomer);
            ViewModel viewModel = new ViewModel();
            //viewModel.pickups.PickUpDate = 
            var currentUserId = User.Identity.GetUserId();

            //viewModel.customers = db.Customers.Find(id);
            viewModel.customers = db.Customers.Where(c => c.ApplicationUserId == currentUserId).SingleOrDefault();
            //db.Addresses.Where(a => a.AddressId == viewModel.address.CustomerId).Single();
            //viewModel.address = db.Addresses.Find(viewModel.customers.AddressId);
            //viewModel.pickups = db.Pickups.Find(viewModel.customers.PickId);

            //viewModel.address = db.Addresses.Find(viewModel.customers.Address);
            //Need To Check
            //ViewBag.CustomerId = new SelectList(db.Users, "CustomerId", "ApplicationUserRoleId", viewModel.customers.CustomerId);
            return View(viewModel);
        }

        //=============================================================================================================================

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var editCustomer = db.Customers.Find(viewModel.customers.CustomerId == viewModel.customers.CustomerId);
                var editAddress = db.Addresses.Where(a => a.AddressId == viewModel.address.CustomerId).Single();
                var editPickUps = db.Pickups.Where(p => p.PickUpId == viewModel.customers.PickId).Single();
                editCustomer.FirstName = viewModel.customers.FirstName;
                editCustomer.LastName = viewModel.customers.LastName;
                editAddress.StreetAddress = viewModel.address.StreetAddress;
                editAddress.ZipCode = viewModel.address.ZipCode;
                editPickUps.PickUpDay = viewModel.pickups.PickUpDay;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                

            //if (ModelState.IsValid)
            //{
            //    db.Entry(customers).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Details");
            //}
            ViewBag.ApplicationUserId = new SelectList(db.Users, "CustomerId", "ApplicationUserId", viewModel.customers.ApplicationUserId);
            return View(viewModel);
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
            return RedirectToAction("Index");
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
