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
    public class ProfilesController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: friend Profile
        public ActionResult Index(int? id)
        { 

            string uname = this.User.Identity.Name;
            var friend_List = db.Friend_List.Where(f => f.user_id == id || f.friend_id == id);
            bool friend = friend_List.Any(f => f.User.username == uname || f.User1.username == uname);
            var profile = db.Users.Where(f => f.user_id == id);
            if (friend)
            {
                return View(profile.ToList());
            }
            else
            {
                return RedirectToAction("nonFriend", new { id });
            }
        }
        //GET: non friend profile
        public ActionResult nonFriend(int? id)
        {
            var profile = db.Users.Where(f => f.user_id == id);
            return View(profile.ToList());
        }
    }
}