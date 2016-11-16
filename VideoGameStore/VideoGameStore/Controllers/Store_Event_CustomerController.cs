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
    public class Store_Event_CustomerController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Store_Event_Customer
        public ActionResult Index()
        {
            var store_Event_Customer = db.Store_Event_Customer.Include(s => s.Customer).Include(s => s.Store_Event);
            return View(store_Event_Customer.ToList());
        }

        // GET: Store_Event_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Customer store_Event_Customer = db.Store_Event_Customer.Find(id);
            if (store_Event_Customer == null)
            {
                return HttpNotFound();
            }
            return View(store_Event_Customer);
        }

        // GET: Store_Event_Customer/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username");
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name");
            return View();
        }

        // POST: Store_Event_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "store_event_customer_id,store_event_id,customer_id")] Store_Event_Customer store_Event_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Store_Event_Customer.Add(store_Event_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", store_Event_Customer.customer_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Customer.store_event_id);
            return View(store_Event_Customer);
        }

        // GET: Store_Event_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Customer store_Event_Customer = db.Store_Event_Customer.Find(id);
            if (store_Event_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", store_Event_Customer.customer_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Customer.store_event_id);
            return View(store_Event_Customer);
        }

        // POST: Store_Event_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "store_event_customer_id,store_event_id,customer_id")] Store_Event_Customer store_Event_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store_Event_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", store_Event_Customer.customer_id);
            ViewBag.store_event_id = new SelectList(db.Store_Event, "store_event_id", "store_event_name", store_Event_Customer.store_event_id);
            return View(store_Event_Customer);
        }

        // GET: Store_Event_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event_Customer store_Event_Customer = db.Store_Event_Customer.Find(id);
            if (store_Event_Customer == null)
            {
                return HttpNotFound();
            }
            return View(store_Event_Customer);
        }

        // POST: Store_Event_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store_Event_Customer store_Event_Customer = db.Store_Event_Customer.Find(id);
            db.Store_Event_Customer.Remove(store_Event_Customer);
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
