using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class QuanLyCaController : Controller
    //public class QuanLyCaController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyCa
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.GroupProduct);

            return View(products.ToList());
        }

        // GET: Admin/QuanLyCa/Details/5
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

        // GET: Admin/QuanLyCa/Create
        public ActionResult Create()
        {
            var productDao = new ProductDao();
            //khai báo view bag để bỏ qua view cái thằng typeid =1
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.GetTypeId() == 1), "IdGroupProduct", "Name");
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var pro = new Product();
                pro.IdProduct = product.IdProduct;
                pro.IdGroupProduct = product.IdGroupProduct;
                pro.Name = product.Name;
                pro.Detail = product.Detail;
                pro.Price = product.Price;
                pro.Image = product.Image;
                pro.PriceNew = 0;
                pro.Date = DateTime.Now;
                pro.Status = product.Status;
                pro.Size = product.Size;
                long id = dao.Insert(pro);
                if(id > 0)
                {
                    return RedirectToAction("Index", "QuanLyCa");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm thất bại");
                }
       
            }

            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts, "IdGroupProduct", "Name", product.IdGroupProduct);
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View("Index");

        }

        // GET: Admin/QuanLyCa/Edit/5
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
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts, "IdGroupProduct", "Name", product.IdGroupProduct);
           
            return View(product);
        }

        // POST: Admin/QuanLyCa/Edit/5
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
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View(product);
        }

        // GET: Admin/QuanLyCa/Delete/5
        //Khởi tạo trang delete
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

        // POST: Admin/QuanLyCa/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //Delete bằng ajax
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
