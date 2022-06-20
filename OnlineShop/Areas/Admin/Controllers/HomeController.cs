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
    [HandleError]
    public class HomeController : BaseController
   // public class HomeController : Controller
    {

        private ShopDbContext db = new ShopDbContext();
        // GET: Admin/Home
        public ActionResult Home()
        {
            try
            {
                var product = new ProductDao().getCount();
                var order = new OrderDao().getCount();
                var user = new AdminDao().getCountUser();

                Session["CountPro"] = product;
                Session["Order"] = order;
                Session["User"] = user;

                return View();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return RedirectToAction("Error", "Error");
            }
            //lấy session bỏ vào 3 cái ở trang home

        }
        
    }
}