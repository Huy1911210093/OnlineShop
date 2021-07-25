using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.Admin.Common;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;

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

        //LOGIN DÙNG SESSION

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                var dao = new AdminDao();
                var result = dao.Login(model.Email, EncryptPassword.MD5Hash(model.Password));

                switch (result)
                {
                    case 1:
                        var admin = dao.GetByEmail(model.Email);
                        var adminSession = new UserLogin();
                        adminSession.Email = admin.Email;
                        adminSession.UserId = admin.GetId();
                        Session.Add(CommonConstant.ADMIN_SESSION, adminSession);
                        Session["FirstName"] = admin.FirstName;
                        Session["LastName"] = admin.LastName;
                        Session["Email"] = admin.Email;
                        Session["Password"] = admin.Password;
                        Session["Id"] = adminSession.UserId;
                        return RedirectToAction("Home", "Home");
                    case 0:
                        ModelState.AddModelError("", "Tài khoản chưa có!");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Sai mật khẩu");
                        break;

                }

            }
            return View("Index");

        }

        public ActionResult Logout()
        {
            Session["LastName"] = null;
            return RedirectToAction("Index", "LogIn");
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