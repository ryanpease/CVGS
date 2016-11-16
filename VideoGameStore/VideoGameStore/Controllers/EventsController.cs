/* Filename: EventsController.cs
 * Description: This class is responsible for interaction with the Store_Event data.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created
*/

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
    public class EventsController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Events
        public ActionResult Index()
        {
            var store_Event = db.Store_Event.Include(s => s.Address);
            return View(store_Event.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event store_Event = db.Store_Event.Find(id);
            if (store_Event == null)
            {
                return HttpNotFound();
            }
            return View(store_Event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "store_event_id,store_event_name,description,address_id,start_date,end_date,max_registrants,is_full,is_members_only,is_cancelled")] Store_Event store_Event)
        {
            if (ModelState.IsValid)
            {
                db.Store_Event.Add(store_Event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", store_Event.address_id);
            return View(store_Event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event store_Event = db.Store_Event.Find(id);
            if (store_Event == null)
            {
                return HttpNotFound();
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", store_Event.address_id);
            return View(store_Event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "store_event_id,store_event_name,description,address_id,start_date,end_date,max_registrants,is_full,is_members_only,is_cancelled")] Store_Event store_Event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store_Event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", store_Event.address_id);
            return View(store_Event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store_Event store_Event = db.Store_Event.Find(id);
            if (store_Event == null)
            {
                return HttpNotFound();
            }
            return View(store_Event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store_Event store_Event = db.Store_Event.Find(id);
            db.Store_Event.Remove(store_Event);
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
