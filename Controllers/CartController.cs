using Groupon.Models.Context;
using Groupon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupon.Controllers
{
    public class CartController : Controller
    {
        GrouponContext db = new GrouponContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }




        
        public ActionResult AddToCart(int id)
        {
            if(Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                //Sepete eklenen ürünü getir.
                var product = db.Product.Find(id);
                //ürün varsa : 
                if (product != null)
                {
                    GetCart().AddProduct(product, 1);
                }
            }
           
         

            return RedirectToAction("Index");
        }
        

        public ActionResult RemoveFromCart(int id)
        {
            //Sepete eklenen ürünü getir.
            var product = db.Product.Where(i => i.ProductID == id).FirstOrDefault();
            //ürün varsa : 
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            //Her kullanıya ait cart oluşturuluyor.
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }


        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "You have no product in your cart.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();

                return View("Completed");
            }
            else
            {
                return View(entity);
            }

        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = (new Random()).Next(111111,999999);
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.FullName = entity.FullName;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price =pr.Quantity * pr.Product.Price;
                orderline.ProductID = pr.Product.ProductID;
                

                order.OrderLines.Add(orderline);

            }
            db.Orders.Add(order);
            db.SaveChanges();

        }

       
    }
}