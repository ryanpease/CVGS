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
    public class Store_Event_EmployeeController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Store_Event_Employee
        public ActionResult Index()
        {
            var store_Event_Employee = db.Store_Event_Employee.Include(s => s.Employee).Include(s => s.Store_Event);
            return View(store_Event_Employee.ToList());
        }

        // GET: Store_Event_Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Employee store_Event_Employee = db.Store_Event_Employee.Find(id);
            if (store_Event_Employee == null)
            {
                return HttpNotFound();
            }
            return View(store_Event_Employee);
        }

        // GET: Store_Event_Employee/Create
        public ActionResult Create()
        {
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username");
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name");
            return View();
        }

        // POST: Store_Event_Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "store_event_employee_id,store_event_id,employee_id")] Store_Event_Employee store_Event_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Store_Event_Employee.Add(store_Event_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", store_Event_Employee.employee_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Employee.store_event_id);
            return View(store_Event_Employee);
        }

        // GET: Store_Event_Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Employee store_Event_Employee = db.Store_Event_Employee.Find(id);
            if (store_Event_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", store_Event_Employee.employee_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Employee.store_event_id);
            return View(store_Event_Employee);
        }

        // POST: Store_Event_Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "store_event_employee_id,store_event_id,employee_id")] Store_Event_Employee store_Event_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store_Event_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "employee_id", "username", store_Event_Employee.employee_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Employee.store_event_id);
            return View(store_Event_Employee);
        }

        // GET: Store_Event_Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Employee store_Event_Employee = db.Store_Event_Employee.Find(id);
            if (store_Event_Employee == null)
            {
                return HttpNotFound();
            }
            return View(store_Event_Employee);
        }

        // POST: Store_Event_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store_Event_Employee store_Event_Employee = db.Store_Event_Employee.Find(id);
            db.Store_Event_Employee.Remove(store_Event_Employee);
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
