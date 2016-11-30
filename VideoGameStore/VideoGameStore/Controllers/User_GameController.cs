using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;
using System.Security.Claims;

namespace VideoGameStore.Controllers
{
    public class User_GameController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: User_Game
        public ActionResult Index()
        {
            int userID = 1;//GetUserID();
            var user_Game = db.User_Game.Include(u => u.Game).Include(u => u.User).Where(u => u.user_id == userID);
            var game = (from g in db.Games join u in db.User_Game on g.game_id equals u.game_id where u.user_id == userID select new {g.description, g.image_location, g.game_name, u.rating, u.date_purchased, u.game_id});
            return View(user_Game.ToList());
        }

        /// <summary>
        /// Gets the current users id
        /// </summary>
        /// <returns>user id as int</returns>
        private int GetUserID()
        {
            //U

            //int id = 0;
            //if (Int32.TryParse(userid.ToString(), out id))
            //{
            //    return id;
            //}
            //else
            //{
            //    return id;
            //}
            return 0;
        }

        // GET: User_Game/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_Game user_Game = db.User_Game.Find(id);
        //    if (user_Game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_Game);
        //}

        //// GET: User_Game/Create
        //public ActionResult Create()
        //{
        //    ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name");
        //    ViewBag.user_id = new SelectList(db.Users, "user_id", "username");
        //    return View();
        //}

        //// POST: User_Game/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "user_game_id,user_id,game_id,date_purchased,rating")] User_Game user_Game)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.User_Game.Add(user_Game);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", user_Game.game_id);
        //    ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Game.user_id);
        //    return View(user_Game);
        //}

        //// GET: User_Game/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_Game user_Game = db.User_Game.Find(id);
        //    if (user_Game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", user_Game.game_id);
        //    ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Game.user_id);
        //    return View(user_Game);
        //}

        //// POST: User_Game/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "user_game_id,user_id,game_id,date_purchased,rating")] User_Game user_Game)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user_Game).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.game_id = new SelectList(db.Games, "game_id", "game_name", user_Game.game_id);
        //    ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Game.user_id);
        //    return View(user_Game);
        //}

        //// GET: User_Game/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_Game user_Game = db.User_Game.Find(id);
        //    if (user_Game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_Game);
        //}

        //// POST: User_Game/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User_Game user_Game = db.User_Game.Find(id);
        //    db.User_Game.Remove(user_Game);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
