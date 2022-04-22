using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Groupon.Models.Context;
using Groupon.Models.Entity;

namespace Groupon.Controllers
{
    public class ProductController : Controller
    {
        private GrouponContext db = new GrouponContext();

        // GET: Product
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Category);
            return View(product.ToList());
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Title");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imgInfo = new FileInfo(Image.FileName);

                    string imgname = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(940, 400);
                    img.Save("~/Uploads/Product/" + imgname);
                    product.Image = "/Uploads/Product/" + imgname;
                }
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Title", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Title", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Product product,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var a = db.Product.Where(c => c.ProductID == id).SingleOrDefault();
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
                    img.Save("~/Uploads/Product/" + productname);
                    a.Image = "/Uploads/Product/" + productname;
                }
                a.Price = product.Price;
                a.SalePercent = product.SalePercent;
                a.Stock = product.Stock;
                a.Title = product.Title;
                a.Description = product.Description;
                a.CategoryId = product.CategoryId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Title", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
