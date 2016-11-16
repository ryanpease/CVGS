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
    public class Customer_AddressController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Customer_Address
        public ActionResult Index()
        {
            var customer_Address = db.Customer_Address.Include(c => c.Address).Include(c => c.Customer);
            return View(customer_Address.ToList());
        }

        // GET: Customer_Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Address customer_Address = db.Customer_Address.Find(id);
            if (customer_Address == null)
            {
                return HttpNotFound();
            }
            return View(customer_Address);
        }

        // GET: Customer_Address/Create
        public ActionResult Create()
        {
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address");
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username");
            return View();
        }

        // POST: Customer_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,address_id,address_name")] Customer_Address customer_Address)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Address.Add(customer_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", customer_Address.address_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Address.customer_id);
            return View(customer_Address);
        }

        // GET: Customer_Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Address customer_Address = db.Customer_Address.Find(id);
            if (customer_Address == null)
            {
                return HttpNotFound();
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", customer_Address.address_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Address.customer_id);
            return View(customer_Address);
        }

        // POST: Customer_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,address_id,address_name")] Customer_Address customer_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", customer_Address.address_id);
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Address.customer_id);
            return View(customer_Address);
        }

        // GET: Customer_Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Address customer_Address = db.Customer_Address.Find(id);
            if (customer_Address == null)
            {
                return HttpNotFound();
            }
            return View(customer_Address);
        }

        // POST: Customer_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Address customer_Address = db.Customer_Address.Find(id);
            db.Customer_Address.Remove(customer_Address);
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
