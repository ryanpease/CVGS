using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class Employee_AddressController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Employee_Address
        public ActionResult Index()
        {
            var employee_Address = db.Employee_Address.Include(e => e.Address).Include(e => e.Employee);
            return View(employee_Address.ToList());
        }

        // GET: Employee_Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Address employee_Address = db.Employee_Address.Find(id);
            if (employee_Address == null)
            {
                return HttpNotFound();
            }
            return View(employee_Address);
        }

        // GET: Employee_Address/Create
        public ActionResult Create()
        {
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address");
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username");
            return View();
        }

        // POST: Employee_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_id,address_id,address_name")] Employee_Address employee_Address)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Address.Add(employee_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", employee_Address.address_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", employee_Address.employee_id);
            return View(employee_Address);
        }

        // GET: Employee_Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Address employee_Address = db.Employee_Address.Find(id);
            if (employee_Address == null)
            {
                return HttpNotFound();
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", employee_Address.address_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", employee_Address.employee_id);
            return View(employee_Address);
        }

        // POST: Employee_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,address_id,address_name")] Employee_Address employee_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", employee_Address.address_id);
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", employee_Address.employee_id);
            return View(employee_Address);
        }

        // GET: Employee_Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Address employee_Address = db.Employee_Address.Find(id);
            if (employee_Address == null)
            {
                return HttpNotFound();
            }
            return View(employee_Address);
        }

        // POST: Employee_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Address employee_Address = db.Employee_Address.Find(id);
            db.Employee_Address.Remove(employee_Address);
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
