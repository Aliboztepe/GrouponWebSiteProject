using Groupon.Models.Context;
using Groupon.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Groupon.Controllers
{
    public class SliderController : Controller
    {
        private GrouponContext db = new GrouponContext();
        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imgInfo = new FileInfo(Image.FileName);

                    string imgname = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(940, 400);
                    img.Save("~/Uploads/Slider/" + imgname);
                    slider.Image = "/Uploads/Slider/" + imgname;
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Slider slider, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var a = db.Slider.Where(c => c.SliderID== id).SingleOrDefault();
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(a.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(a.Image));
                    }
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imgInfo = new FileInfo(Image.FileName);

                    string productname = Image.FileName + imgInfo.Extension;
                    img.Resize(940, 400);
                    img.Save("~/Uploads/Slider/" + productname);
                    a.Image = "/Uploads/Slider/" + productname;
                }
               
                a.Description = slider.Description;
                a.Title = slider.Title;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(slider);
        }
        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            db.Slider.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}