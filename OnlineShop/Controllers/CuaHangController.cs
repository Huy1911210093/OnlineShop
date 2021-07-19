using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CuaHangController : Controller
    {
        // GET: CuaHang
        ShopDbContext objWebsiteCuaHang = new ShopDbContext();
        public ActionResult Index()
        {
            var lstCuaHang = objWebsiteCuaHang.Products.Where(n => n.GroupProduct.TypeId == 1).ToList();
            return View(lstCuaHang);
        }
        public ActionResult CaVang()
        {
            var listCaVang = objWebsiteCuaHang.Products.Where(n => n.IdGroupProduct == 1).ToList();
            return View(listCaVang);
        }
        public ActionResult Guppy()
        {
            var listGuppy = objWebsiteCuaHang.Products.Where(n => n.IdGroupProduct == 4).ToList();
            return View(listGuppy);
        }
        public ActionResult Betta()
        {
            var listBetta = objWebsiteCuaHang.Products.Where(n => n.IdGroupProduct == 5).ToList();
            return View(listBetta);
        }
        public ActionResult LaHan()
        {
            var listLaHan = objWebsiteCuaHang.Products.Where(n => n.IdGroupProduct == 2).ToList();
            return View(listLaHan);
        }
        public ActionResult Koi()
        {
            var listKoi = objWebsiteCuaHang.Products.Where(n => n.IdGroupProduct == 3).ToList();
            return View(listKoi);
        }
    }
}