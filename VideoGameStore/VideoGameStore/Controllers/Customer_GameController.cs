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
    public class Customer_GameController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Customer_Game
        public ActionResult Index()
        {
            var customer_Game = db.Customer_Game.Include(c => c.Customer).Include(c => c.Game);
            return View(customer_Game.ToList());
        }

        // GET: Customer_Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Game customer_Game = db.Customer_Game.Find(id);
            if (customer_Game == null)
            {
                return HttpNotFound();
            }
            return View(customer_Game);
        }

        // GET: Customer_Game/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username");
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name");
            return View();
        }

        // POST: Customer_Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_game_id,customer_id,game_id,date_purchased,rating")] Customer_Game customer_Game)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Game.Add(customer_Game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Game.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", customer_Game.game_id);
            return View(customer_Game);
        }

        // GET: Customer_Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Game customer_Game = db.Customer_Game.Find(id);
            if (customer_Game == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Game.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", customer_Game.game_id);
            return View(customer_Game);
        }

        // POST: Customer_Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_game_id,customer_id,game_id,date_purchased,rating")] Customer_Game customer_Game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "username", customer_Game.customer_id);
            ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", customer_Game.game_id);
            return View(customer_Game);
        }

        // GET: Customer_Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Game customer_Game = db.Customer_Game.Find(id);
            if (customer_Game == null)
            {
                return HttpNotFound();
            }
            return View(customer_Game);
        }

        // POST: Customer_Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Game customer_Game = db.Customer_Game.Find(id);
            db.Customer_Game.Remove(customer_Game);
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
