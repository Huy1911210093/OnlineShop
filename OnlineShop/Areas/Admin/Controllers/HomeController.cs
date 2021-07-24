using OnlineShop.Areas.Admin.Models.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    //public class HomeController : BaseController
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Home()
        {
            //lấy session bỏ vào 3 cái ở trang home
            var product = new ProductDao().getCount();
            var order = new OrderDao().getCount();
            var user = new AdminDao().getCount();
            Session["CountPro"] = product;
            Session["Order"] = order;
            Session["User"] = user;


            return View();
        }
    }
}