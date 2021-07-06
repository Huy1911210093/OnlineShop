using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Common;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using OnlineShop.Models.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{ 
    public class LogInController : Controller
    {
        ShopDbContext objModel = new ShopDbContext();
        // GET: Admin/LogIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }


        //LOGIN DÙNG SESSION

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new AdminDao();
                var result = dao.Login(model.Email, model.Password);

                if (result)
                {
                    var admin = dao.GetById(model.Email);
                    var adminSession = new UserLogin();
                    adminSession.Email = admin.Email;
                    adminSession.UserId = admin.Id;
                    Session.Add(CommonConstant.ADMIN_SESSION,adminSession);
                    Session["Name"] = admin.LastName;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai email hoặc mật khẩu");
                }

            }
            return View("Index");

        }
        //login dùng linq trỏ thẳng tới db

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogIn(string email, string password)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = objModel.Admins.Where(m => m.Email.Equals(email) & m.Password.Equals(password)).ToList();
        //        if (data.Count > 0)
        //        {
        //            Session["Fullname"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
        //            Session["Email"] = data.FirstOrDefault().Email;
        //            Session["Id"] = data.FirstOrDefault().Id;
        //            return RedirectToAction("Home", "Home");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Sai tên hoặc mật khẩu";

        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View();

        //}

    }
}