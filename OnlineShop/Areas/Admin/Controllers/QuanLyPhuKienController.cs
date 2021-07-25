using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class QuanLyPhuKienController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyPhuKien
        public ActionResult Index(string search,int page = 1, int pageSize = 4)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(search,page, pageSize);
            ViewBag.Search = search;
            return View(model);
        }

        // GET: Admin/QuanLyPhuKien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/QuanLyPhuKien/Create
        public ActionResult Create()
        {
            var productDao = new ProductDao();

            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.TypeId == 2), "IdGroupProduct", "Name");
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View();
        }

        // POST: Admin/QuanLyPhuKien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var pro = new Product();
                pro.IdProduct = product.IdProduct;
                pro.IdGroupProduct = product.IdGroupProduct;
                string path = Path.Combine(Server.MapPath("~/Content/assets/images/best-product/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);
                pro.Name = product.Name;
                pro.Detail = product.Detail;
                pro.Price = product.Price;
                pro.Image = file.FileName;
                pro.PriceNew = 0;
                pro.Date = DateTime.Now;
                pro.Status = product.Status;
                long id = dao.Insert(pro);
                if (id > 0)
                {
                    return RedirectToAction("Index", "QuanLyPhuKien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }

            }

            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts, "IdGroupProduct", "Name", product.IdGroupProduct);
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View("Create");
        }

        // GET: Admin/QuanLyPhuKien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.TypeId == 2), "IdGroupProduct", "Name");
            return View(product);
        }

        // POST: Admin/QuanLyPhuKien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,IdGroupProduct,Name,Detail,Price,Image,PriceNew,Date,Status,Size")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts, "IdGroupProduct", "Name", product.IdGroupProduct);
            return View(product);
        }

        // GET: Admin/QuanLyPhuKien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

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
