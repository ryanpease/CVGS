/* Filename: CartController.cs
 * Description: This class is responsible for handing the interaction between the user and the cart model.
 * 
 * Revision History:
 *     Ryan Pease, 2016-11-29: Created 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class CartController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Cart
        //public ViewResult Index(Cart cart, string returnUrl)
        //{
        //    return View(new CartIndexViewModel
        //    {
        //        ReturnUrl = returnUrl,
        //        Cart = cart
        //    });
        //}

        [AllowAnonymous]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //public RedirectToRouteResult AddToCart(Cart cart, int game_id, string returnUrl)
        //{
        //    Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();

        //    if (game != null)
        //    {
        //        cart.AddItem(game, 1);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //public RedirectToRouteResult RemoveFromCart(Cart cart, int game_id, string returnUrl)
        //{
        //    Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();

        //    if (game != null)
        //    {
        //        cart.RemoveItem(game);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}

        [AllowAnonymous]
        //GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        [Authorize(Roles ="Customer, Admin, Employee")]  //user must be logged in/registered in order to check out
        public ViewResult Checkout()
        {
            // get current user_id
            int user_id = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
     
            // create a list of the user's addresses and credit cards - these will be displayed in a dropdown list
            var addresses = db.User_Address.Where(a => a.user_id == user_id).ToList();
            var creditcards = db.Credit_Card.Where(c => c.user_id == user_id).ToList();
            int numAddresses = addresses.Count();
            int numCards = creditcards.Count();
            ViewBag.numCards = numCards;
            ViewBag.numAddresses = numAddresses;
            ViewBag.user_id = user_id;
            ViewBag.userAddress = new SelectList(addresses, "address_id", "Address.street_address");
            ViewBag.creditCards = new SelectList(creditcards, "credit_card_id", "card_number");
     
            return View();
        }

        public RedirectToRouteResult AddToCart(int game_id, string returnUrl)
        {
            Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();

            if (game != null)
            {
                GetCart().AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int game_id, string returnUrl)
        {
            Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();

            if (game != null)
            {
                GetCart().RemoveItem(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}