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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            //string currentUserId = User.Identity.GetUserId();
            //var employee = db.Employees.Where(c => c.ApplicationUserId == currentUserId).First();

           // var ListOfCustomers = db.Customers.Where(x => x.Address.ZipCode == employee.ZipCode && (x.PickUpDay == DateTime || x.ExtraPickUp == DateTime).ToList());

            return View(db.Employees.ToList());
        }

        //=============================================================================================================================

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            Employees employeeDetails = null;
            if (id == null)
            {
                string currentUserId = User.Identity.GetUserId();
                employeeDetails = db.Employees.Where(c => c.ApplicationUserId == currentUserId).First();
                return View(employeeDetails);
            }
            Employees employees = db.Employees.Find(id);

            if (employees == null)
            {
                return HttpNotFound();
            }
            return View("Details");
        }

        //=============================================================================================================================

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "EmployeeId", "ApplicationRoleId");
            return View();
        }

        //=============================================================================================================================

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "EmployeeId,ApplicationRoleIdFirstName,LastName,ZipCode")] Employees employee)
        {
            if (ModelState.IsValid)
            {
                // get the Id of the currently logged in ApplicationUser
                string currentUserId = User.Identity.GetUserId();
                employee.ApplicationUserId = currentUserId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "EmployeerId", "ApplicationUserId", employee.ApplicationUserId);
            return View(employee);
        }

        //=============================================================================================================================

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            //Need To Check
            //ViewBag.ApplicationUserId = new SelectList(db.Users, "EmployeeId", "ApplicationUseerId", employees.ApplicationUserId);
            return View(employees);
        }

        //=============================================================================================================================

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,ZipCode")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "EmployeeId", "ApplicationUserId", employees.ApplicationUserId);
            return View(employees);
        }

        //=============================================================================================================================

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        //=============================================================================================================================

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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
