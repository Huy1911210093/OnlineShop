using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{ 
    public class LogInController : Controller
    {
        OnlineFishShopEntities objModel = new OnlineFishShopEntities();
        // GET: Admin/LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var data = objModel.Admins.Where(m => m.Email.Equals(email) & m.Password.Equals(password)).ToList();
                if(data.Count > 0)
                {
                    Session["Fullname"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Id"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ViewBag.error = "Sai tên hoặc mật khẩu";
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
    }
}