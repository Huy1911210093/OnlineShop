using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/DonHang
        public ActionResult Index()
        {
            //var dao = new OrderDao();
            //var model = dao.ListAllPaging(page, pageSize);
            var orders = db.Orders.Include(o => o.UserAccount);
            return View(orders.ToList());
            //return View(model);
        }
        [HttpPost]
        public ActionResult ChiTietDonHang(int id)
        {
            if (ModelState.IsValid)
            {
                var data = db.OrderDetails.Where(m => m.IdOder.Equals(id)).ToList();
                if (data.Count > 0)
                {
                    Session["Id"] = data.FirstOrDefault().IdOder;
                    return RedirectToAction("ChiTietDonHang");
                }
                else
                {
                    //ViewBag.error = "Sai tên hoặc mật khẩu";

                    //return RedirectToAction("Index");
                }
            }
            return View();
        }
        // GET: Admin/DonHang/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/DonHang/Create
        public ActionResult Create()
        {
            ViewBag.IdUserAccount = new SelectList(db.UserAccounts, "IdUser", "Email");
            return View();
        }

        // POST: Admin/DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOder,IdUserAccount,ShipName,ShipMobile,ShipAddress,ShipEmail,Date,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUserAccount = new SelectList(db.UserAccounts, "IdUser", "Email", order.IdUserAccount);
            return View(order);
        }

        // GET: Admin/DonHang/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.IdUserAccount = new SelectList(db.UserAccounts, "IdUser", "Email", order.IdUserAccount);
            return View(order);
        }

        // POST: Admin/DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOder,IdUserAccount,ShipName,ShipMobile,ShipAddress,ShipEmail,Date,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUserAccount = new SelectList(db.UserAccounts, "IdUser", "Email", order.IdUserAccount);
            return View(order);
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

        // POST: Admin/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
