/* Filename: GamesController.cs
 * Description: This class is responsible for interaction with the Game data.
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
    public class GamesController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Developer).Include(g => g.Genre).Include(g => g.Publisher);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name");
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name");
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "game_id,game_name,description,cost,list_price,on_hand,developer_id,publisher_id,genre_id,release_date,is_on_sale,is_discontinued,is_downloadable,is_physical_copy")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "game_id,game_name,description,cost,list_price,on_hand,developer_id,publisher_id,genre_id,release_date,is_on_sale,is_discontinued,is_downloadable,is_physical_copy")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
