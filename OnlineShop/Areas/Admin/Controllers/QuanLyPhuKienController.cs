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
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class QuanLyPhuKienController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyPhuKien
        public ActionResult Index(string search,int page = 1, int pageSize = 4)
        {
            IQueryable<Product> model = db.Products.Where(m => m.GroupProduct.TypeId == 2);//phải convert sang kiểu này mới search được
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(m => m.Name.Contains(search) || m.GroupProduct.Name.Contains(search)); //contains: tìm gần đúng theo tên và số lượng
            }

            //truyền ra số bản ghi và số trang
            var listPhukien = model.OrderByDescending(m => m.Date).ToPagedList(page, pageSize);
            ViewBag.Search = search;
            return View(listPhukien);
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
                pro.PriceNew = product.PriceNew;
                pro.Date = DateTime.Now;
                pro.Status = product.Status;
                long id = dao.Insert(pro);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Create", "QuanLyPhuKien");
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
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //quăng về error
                Response.StatusCode = 404;
                return RedirectToAction("Error", "Error");
            }
            var product = new ProductDao().getById(id);
            if (product == null)
            {
                //quăng về error
                Response.StatusCode = 404;
                return RedirectToAction("Error", "Error");
                //return HttpNotFound();
            }
            ViewBag.IdGroupProduct = new SelectList(db.GroupProducts.Where(m => m.TypeId == 2), "IdGroupProduct", "Name");

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
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "QuanLyPhuKien");
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

        // GET: Admin/QuanLyPhuKien/Delete/5

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(new ProductDao().Delete(id))
            {
                SetAlert("Xóa sp thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Sản phẩm đang có trong đơn hàng. Không thể xóa", "error");

            }
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
