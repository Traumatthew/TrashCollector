using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pickups
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            //var pickups = db.Customers.Where(p => p.Address.ZipCode == 
            //var pickups = db.Pickups.Include(p => p.Employees);
            return View("Index");
        }

        // GET: Pickups/Details/5
        public ActionResult Details(int? id)
        {
            //Employees employee = db.Employees.Where(e => e.EmployeeId == User.Identity.Name)
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            return View(pickups);
        }

        // GET: Pickups/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationUserId");
            return View();
        }

        // POST: Pickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickUpId,EmployeeId,PickUpSuspensionBegins,PickUpSuspensionEnds,ExtraPickUp,PickUpCompleted,Charge,PickUpDay,ZipCode")] Pickups pickups)
        {
            if (ModelState.IsValid)
            {
                db.Pickups.Add(pickups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationUserId", pickups.EmployeeId);
            return View(pickups);
        }

        // GET: Pickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationUserId", pickups.EmployeeId);
            return View(pickups);
        }

        // POST: Pickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickUpId,EmployeeId,PickUpSuspensionBegins,PickUpSuspensionEnds,ExtraPickUp,PickUpCompleted,Charge,PickUpDay,ZipCode")] Pickups pickups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationUserId", pickups.EmployeeId);
            return View(pickups);
        }

        // GET: Pickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            return View(pickups);
        }

        // POST: Pickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pickups pickups = db.Pickups.Find(id);
            db.Pickups.Remove(pickups);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
