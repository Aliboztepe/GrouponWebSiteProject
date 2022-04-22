using Groupon.Models.Context;
using Groupon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Groupon.Controllers
{
    public class LoginController : Controller
    {
        private GrouponContext db = new GrouponContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userinfo = db.User.FirstOrDefault(x => x.Email == user.Email && x.password == user.password);
            if(userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.Email, false);
                Session["UserName"] = userinfo.Name.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            //var a = db.User.Where(u => u.Email == user.Email).FirstOrDefault();
            //if(a.Email == user.Email && a.password == user.password)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
           
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
                if(user.password == user.passwordAgain)
                {
                    db.User.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }

            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}