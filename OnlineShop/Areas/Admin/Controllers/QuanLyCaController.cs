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
    public class QuanLyCaController : Controller
    //public class QuanLyCaController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyCa
        public ActionResult Index(string search,int page = 1, int pageSize = 4)
        {

            var dao = new ProductDao();
            var model = dao.ListAllPaging(search,page, pageSize);
            ViewBag.Search = search;
            dao.GetByType(1);
            return View(model);
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
        [HttpGet]
        public ActionResult Create()
        {
            var productDao = new ProductDao();
            //khai báo view bag để bỏ qua view cái thằng typeid =1
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.TypeId == 1), "IdGroupProduct", "Name");
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View();
        }

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
                pro.Image =  file.FileName;
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
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //quăng về error
                Response.StatusCode = 404;
                return RedirectToAction("Index","Error");
            }
            var product = new ProductDao().getById(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Index", "Error");
                //return HttpNotFound();
            }
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.TypeId == 1), "IdGroupProduct", "Name");

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var id = dao.Update(product);
                if (id)
                {
                    return RedirectToAction("Index", "QuanLyCa");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa sản phẩm thất bại");
                }

            }

            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts, "IdGroupProduct", "Name", product.IdGroupProduct);
            ViewBag.DVT = new SelectList(db.GroupProducts, "IdGroupProduct", "DVT");
            return View("Index");
        }


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
