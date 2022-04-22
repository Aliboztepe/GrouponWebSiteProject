using Groupon.Models.Context;
using Groupon.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Groupon.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        GrouponContext db = new GrouponContext();
        public ActionResult Index(string p, int page = 1)
        {
           if(p != null)
            {
                return View(db.Product.Where(x => x.Title.Contains(p) || p == null).ToList().ToPagedList(page, 9));

            }

            return View(db.Product.ToList().ToPagedList(page, 9));
        }
      

        public PartialViewResult Slider()
        {
            return PartialView(db.Slider.ToList());
        }
     
        public ActionResult Book(int page = 1)
        {
            string a = "Book";
            return View(db.Product.Where(p => p.Category.Title == a).ToList().ToPagedList(page, 9));

        }
        public ActionResult Electronic(int page = 1)
        {
            string a = "Electronic";
            return View(db.Product.Where(p => p.Category.Title == a).ToList().ToPagedList(page, 9));
        }
        public ActionResult Food(int page = 1)
        {
            string a = "Food";
            return View(db.Product.Where(p => p.Category.Title == a).ToList().ToPagedList(page, 9));
        }
        public ActionResult Travel(int page = 1)
        {
            string a = "Travel";
            return View(db.Product.Where(p => p.Category.Title == a).ToList().ToPagedList(page, 9));
        }
        public ActionResult Education(int page = 1)
        {
            string a = "Education";
            return View(db.Product.Where(p => p.Category.Title == a).ToList().ToPagedList(page, 9));
        }
        public PartialViewResult Sidebar()
        {
            return PartialView(db.Category.ToList());
        }


        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Content()
        {
            return View();
        }
        [Route("ProductDetail/{id}")] 
        public ActionResult ProductDetail(int id)
        {
            var detail = db.Product.Include("Category").Where(p => p.ProductID == id).FirstOrDefault();
            return View(detail);
        }

        public PartialViewResult Contactinfo()
        {
            return PartialView(db.Contact.SingleOrDefault());
        }

        public ActionResult About()
        {
            return View(db.About.SingleOrDefault());
        }

        public ActionResult Contact()
        {
            return View(db.Contact.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Contact(string Name = null, string Email = null, string Subject = null, string Message = null)
        {
            ViewBag.Message = "İletişim Sayfası";
            if (Name != null && Email != null)
            {
                MailMessage mailim = new MailMessage();
                mailim.To.Add("aliboztepesite@gmail.com");
                mailim.From = new MailAddress("dealproducts12@gmail.com");
                mailim.Subject = "" + Subject;
                mailim.Body = "Sayın yetkili, <br><br> '" + Name + "' kişisinden gelen mesajın içeriği; <br><br> " + Message + " <br><br> Gönderenin E-mail Adresi:&nbsp;&nbsp; " + Email;
                mailim.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("dealproducts12@gmail.com", "123web123");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(mailim);
                TempData["Uyari"] = "Mesajınız başarılı bir şekilde iletilmiştir.";
            }
            else
            {
                TempData["Uyari"] = "Hata Oluştu. Lütfen tekrar deneyiniz.";
            }
            return View();
        }


    }
}