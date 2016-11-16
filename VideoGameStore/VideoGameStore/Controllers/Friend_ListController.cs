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
    public class Friend_ListController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Friend_List
        public ActionResult Index()
        {
            var friend_List = db.Friend_List.Include(f => f.Customer).Include(f => f.Customer1);
            return View(friend_List.ToList());
        }

        // GET: Friend_List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_List friend_List = db.Friend_List.Find(id);
            if (friend_List == null)
            {
                return HttpNotFound();
            }
            return View(friend_List);
        }

        // GET: Friend_List/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username");
            ViewBag.friend_id = new SelectList(db.Customers, "customer_id", "username");
            return View();
        }

        // POST: Friend_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,friend_id,is_family,date_added")] Friend_List friend_List)
        {
            if (ModelState.IsValid)
            {
                db.Friend_List.Add(friend_List);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", friend_List.customer_id);
            ViewBag.friend_id = new SelectList(db.Customers, "customer_id", "username", friend_List.friend_id);
            return View(friend_List);
        }

        // GET: Friend_List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_List friend_List = db.Friend_List.Find(id);
            if (friend_List == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", friend_List.customer_id);
            ViewBag.friend_id = new SelectList(db.Customers, "customer_id", "username", friend_List.friend_id);
            return View(friend_List);
        }

        // POST: Friend_List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,friend_id,is_family,date_added")] Friend_List friend_List)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend_List).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", friend_List.customer_id);
            ViewBag.friend_id = new SelectList(db.Customers, "customer_id", "username", friend_List.friend_id);
            return View(friend_List);
        }

        // GET: Friend_List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend_List friend_List = db.Friend_List.Find(id);
            if (friend_List == null)
            {
                return HttpNotFound();
            }
            return View(friend_List);
        }

        // POST: Friend_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend_List friend_List = db.Friend_List.Find(id);
            db.Friend_List.Remove(friend_List);
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
