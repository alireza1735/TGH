using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace TGH.Models
{
    public class ShoppingCart
    {
        TGHEntities  storeDB = new TGHEntities();
        string ShopingCartID { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShopingCartID = cart.GetCartID(context);
            return cart;
        }
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product,HttpContextBase context)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(a => a.CartID == ShopingCartID && a.ProductID == product.ProductID);
            if (cartItem == null)
            {
                cartItem = new Carts
                {
                    ProductID = product.ProductID,
                    CartID = ShopingCartID,
                    TimeCreated = DateTime.Now,
                    Quantity = 1,
                    Price = product.ProductStores.OrderBy(p => p.TimeCreated).Single().SellPrice
                };
                if (context.Request.IsAuthenticated && storeDB.AccessControls.SingleOrDefault(ac => ac.UserName == context.User.Identity.Name).Fellow)
                    cartItem.Price = product.ProductStores.OrderBy(p => p.TimeCreated).Single().FellowPrice;
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartitem = storeDB.Carts.Single(c => c.ShoppingID == id && c.CartID == ShopingCartID);

            int itemCount = 0;
            if (cartitem != null)
            {
                if (cartitem.Quantity > 1)
                {
                    cartitem.Quantity--;
                    itemCount = cartitem.Quantity;
                }
                else
                {
                    storeDB.Carts.Remove(cartitem);
                }
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(c => c.CartID == ShopingCartID);
            foreach (Carts item in cartItems)
                storeDB.Carts.Remove(item);
            storeDB.SaveChanges();
        }

        public List<Carts> GetCartItems()
        {
            return storeDB.Carts.Where(c => c.CartID == ShopingCartID).ToList<Carts>();
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeDB.Carts where cartItems.CartID == ShopingCartID select (int?)cartItems.Quantity).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Carts where cartItems.CartID == ShopingCartID select (decimal?)cartItems.Quantity * cartItems.Price).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductID,
                    OrderId = order.OrderID,
                    UnitPrice = item.Price,
                    Quantity = item.Quantity
                    
                };
                orderTotal += (item.Quantity * item.Price);
                storeDB.OrderDetails.Add(orderDetail);
            }
            order.OrderStatus = OrderStatus.Pending;
            order.Total = orderTotal;
            storeDB.SaveChanges();
            EmptyCart();
            return order.OrderID;
        }
    
        public string GetCartID(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartID = new Guid();
                    context.Session[CartSessionKey] = tempCartID.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string Username)
        {
            var shoppingCart = storeDB.Carts.Where(s => s.CartID == ShopingCartID);

            foreach (Carts item in shoppingCart)
                item.CartID = Username;
            storeDB.SaveChanges();
        }
    }
}