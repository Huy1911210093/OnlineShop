using OnlineShop.Areas.Admin.Common;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    //public class HomeController : Controller
    {

        private ShopDbContext db = new ShopDbContext();
        // GET: Admin/Home
        public ActionResult Home()
        {
            //lấy session bỏ vào 3 cái ở trang home
            var product = new ProductDao().getCount();
            var order = new OrderDao().getCount();
            var user = new AdminDao().getCountUser();
           
            Session["CountPro"] = product;
            Session["Order"] = order;
            Session["User"] = user;
           
            return View();
        }
        //public ActionResult HoSo(int id)
        //{
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        //quăng về error
        //        return RedirectToAction("Index", "Error");
        //    }
        //    var product = new AdminDao().getByIdAdmin(id);
        //    if (product == null)
        //    {
        //        return RedirectToAction("Index", "Error");
        //        //return HttpNotFound();
        //    }
            

        //    return View(product);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult HoSo()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new AdminDao();
        //        //var id = dao.UpdateAdmin(admin);
        //        entity = new Pro
        //        try
        //        {
        //            var admin = db.Admins.Find(entity.Id);
        //            admin.FirstName = entity.FirstName;
        //            admin.LastName = entity.LastName;
        //            admin.Email = entity.Email;
        //            admin.Password = entity.Password;
        //            db.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //        if (id)
        //        {
        //            return RedirectToAction("Home", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Sửa thông tin tài khoản thất bại");
        //        }

        //    }

        //    return View("Home");
        //}
    }
}