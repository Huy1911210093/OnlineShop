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
using OnlineShop.Models.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new AdminDao();
            var model = dao.ListAllPaging(page, pageSize);
            //return View(products.ToList());
            return View(model);
        }


        // GET: Admin/QuanLyTaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: Admin/QuanLyTaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,FirstName,LastName,Phone,Password,CreatedDay,Status")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: Admin/QuanLyTaiKhoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount user = db.UserAccounts.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //Delete bằng ajax
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AdminDao().Delete(id);

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
