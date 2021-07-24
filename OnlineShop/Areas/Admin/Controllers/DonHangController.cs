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
    public class DonHangController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/DonHang
        public ActionResult Index(int pageNum = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAllPaging(pageNum, pageSize);
            //var orders = db.Orders.Include(o => o.UserAccount);
            //return View(orders.ToList());
            return View(model);
        }

        public ActionResult XacNhan(int id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //quăng về error
                return RedirectToAction("Index", "Error");
            }
            var order = new OrderDao().getById(id);
            if (order == null)
            {
                return RedirectToAction("Index", "Error");
                //return HttpNotFound();
            }


            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhan(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var id = dao.Update(order);
                if (id)
                {
                    return RedirectToAction("Index", "DonHang");
                }
                else
                {
                    ModelState.AddModelError("", "Xác nhận đơn hàng thất bại");
                }

            }


            return View("Index");
        }


        // GET: Admin/DonHang/Create
        public ActionResult Create()
        {
            ViewBag.IdUserAccount = new SelectList(db.UserAccounts, "IdUser", "Email");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDao();
                var order = new Order();


            }
            return View();
        }

        // GET: Admin/DonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new OrderDao().Delete(id);

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
