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
    public class Wish_ListController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Wish_List
        public ActionResult Index()
        {
            var wish_List = db.Wish_List.Include(w => w.Customer).Include(w => w.Game);
            return View(wish_List.ToList());
        }

        // GET: Wish_List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            return View(wish_List);
        }

        // GET: Wish_List/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username");
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name");
            return View();
        }

        // POST: Wish_List/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wish_list_id,customer_id,game_id,date_added")] Wish_List wish_List)
        {
            if (ModelState.IsValid)
            {
                db.Wish_List.Add(wish_List);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", wish_List.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", wish_List.game_id);
            return View(wish_List);
        }

        // GET: Wish_List/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", wish_List.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", wish_List.game_id);
            return View(wish_List);
        }

        // POST: Wish_List/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wish_list_id,customer_id,game_id,date_added")] Wish_List wish_List)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wish_List).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", wish_List.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", wish_List.game_id);
            return View(wish_List);
        }

        // GET: Wish_List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            return View(wish_List);
        }

        // POST: Wish_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish_List wish_List = db.Wish_List.Find(id);
            db.Wish_List.Remove(wish_List);
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
