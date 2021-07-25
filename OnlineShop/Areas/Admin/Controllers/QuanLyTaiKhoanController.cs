using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Common;
using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;
using OnlineShop.Models.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/QuanLyTaiKhoan
        public ActionResult Index(string search,int page = 1, int pageSize = 10)
        {
            var dao = new AdminDao();
            var model = dao.ListAllPaging(search,page, pageSize);
            ViewBag.Search = search;
            return View(model);
        }


        // GET: Admin/QuanLyTaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Index", "Error");
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Index", "Error");
            }
            return View(userAccount);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAccount userAccount)
        {
            if (!string.IsNullOrEmpty(userAccount.Password))
            {
                var encryptPass = EncryptPassword.MD5Hash(userAccount.Password);
                userAccount.Password = encryptPass;
            }
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                
                
                var id = dao.UpdateUser(userAccount);
                if (id)
                {
                    return RedirectToAction("Index", "QuanLyTaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa tài khoản thất bại");
                }

            }

            return View(userAccount);
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
