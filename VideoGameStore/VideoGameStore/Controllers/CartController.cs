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
    [AllowAnonymous]
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

        //GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
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