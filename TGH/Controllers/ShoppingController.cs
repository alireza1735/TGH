using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using TGH.Models;
using TGH.ViewModels;


namespace TGH.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ShoppingController : Controller
    {
        TGHEntities storeDB = new TGHEntities();
        //
        // GET: /Shopping/

        public ActionResult Index()
        {
            var carts = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = carts.GetCartItems(),
                CartTotal = carts.GetTotal()
            };
            return View(viewModel);
        }
        public ActionResult AddToCart(int id)
        {
            ShoppingCart shoppingCart = ShoppingCart.GetCart(this.HttpContext);
            var product = storeDB.Products.Include("ProductStores").SingleOrDefault(p => p.ProductID == id);
            shoppingCart.AddToCart(product, this.HttpContext);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart shoppingCart = ShoppingCart.GetCart(this.HttpContext);
            shoppingCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

    }
}
