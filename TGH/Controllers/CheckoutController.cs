using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TGH.Models;
using Models;
using System.Web.Security;
using TGH.ViewModels;

namespace TGH.Controllers
{
    public class CheckoutController : Controller
    {
        TGHEntities db = new TGHEntities();
        const string OrderNumber = "ordernumber";
        //
        // GET: /Checkout/

        public ActionResult Index(int id)
        {
            Session[OrderNumber] = id;
            return RedirectToAction("Payment");
        }

        public ActionResult ViewOrder()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            if (cart.GetCount() < 1)
                return RedirectToAction("Index", "Shopping");
            List<Carts> carts = cart.GetCartItems();
            MembershipUser msu = Membership.GetUser();
            PaymentViewModel pvm = new PaymentViewModel();
            pvm.CartItem = carts;
            pvm.Total = cart.GetTotal();
            Customer cus = db.Customers.SingleOrDefault(c => c.UserName == User.Identity.Name);
            if (cus != null)
            {
                pvm.Firstname = cus.Name;
                pvm.Lastname = cus.LastName;
                pvm.Phone = cus.Mobile;
                pvm.Email = msu.Email;
            }
            return View(pvm);
        }
        public RedirectToRouteResult ConfirmOrder()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            Order order = new Order();
            Customer cus = db.Customers.SingleOrDefault(c => c.UserName == User.Identity.Name);
            MembershipUser msu = Membership.GetUser();
            if (cus != null)
            {
                order.Firstname = cus.Name;
                order.Lastname = cus.LastName;
                order.Phone = cus.Mobile;
                order.Email = msu.Email;
                order.Total = cart.GetTotal();
            }
            order.Username = User.Identity.Name;
            order.OrderStatus = OrderStatus.Pending;
            order.OrderDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            Session[OrderNumber] = cart.CreateOrder(order);
            return RedirectToAction("Payment");
        }
        public ActionResult Payment()
        {
            int id = Convert.ToInt32(Session[OrderNumber]);
            Order order = db.Orders.SingleOrDefault(o => o.OrderID == id);
            order.Payment = new Payment
            {
                TotalPrice = order.Total,
                PaymentCreted = DateTime.Now,
                PaymentStatus = PaymentStatus.Pending,
                UserName = User.Identity.Name
            };
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string PaymentType)
        {
            return RedirectToAction("Completed");
        }

        public ActionResult Completed()
        {
            return View();
        }
    }
}
