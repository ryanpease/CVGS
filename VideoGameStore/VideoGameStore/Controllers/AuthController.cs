using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;
using System.Security.Claims;

namespace VideoGameStore.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        //// GET: Auth
        //[HttpGet]
        //public ActionResult Login(string returnUrl)
        //{
        //    var model = new LoginModel
        //    {
        //        ReturnUrl = returnUrl
        //    };
        //    return View(model);
        //}

        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                VideoGameStoreDBContext db = new VideoGameStoreDBContext();
                var users = db.Users.Where(u => u.email == model.Email).Where(u => u.user_password == model.Password).ToList();
                if (users.Count == 1)
                {
                    User user = users.FirstOrDefault();
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.first_name),
                    new Claim(ClaimTypes.Email, user.email),
                    },
                        "ApplicationCookie");
                    var context = Request.GetOwinContext();
                    var authManager = context.Authentication;

                    authManager.SignIn(identity);


                    return RedirectToAction("Index", "Home");
                }

                return View(model);
            }

            //if (user.email == "admin@admin.com" && user.user_password == "123456")
            //{
            //var identity = new ClaimsIdentity(new[] {
            //new Claim(ClaimTypes.Name, "Ryan"),
            //new Claim(ClaimTypes.Email, "ryan@email.com"),
            //new Claim(ClaimTypes.Country, "Canada")
            //},
            //    "ApplicationCookie");
            //var context = Request.GetOwinContext();
            //var authManager = context.Authentication;

            //authManager.SignIn(identity);

            //return RedirectToAction("Index", "Home");
            //}
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }
        }

        //private string GetRedirectUrl(string returnUrl)
        //{
        //    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
        //    {
        //        return Url.Action("Index", "Home");
        //    }
        //    return returnUrl;
        //}

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                VideoGameStoreDBContext db = new VideoGameStoreDBContext();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");                
            }
            else
            {
                ModelState.AddModelError("", "One or more fields are invalid");
                return View();
            }            
        }
    }
}