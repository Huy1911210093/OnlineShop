using OnlineShop.Models;
using PagedList;
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
        
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var lstCuaHang = objWebsiteCuaHang.Products
                .Where(p => p.GroupProduct.TypeId == 1)
                .OrderBy(p => p.GroupProduct.TypeId)
                .ToPagedList(page, pageSize);
            return View(lstCuaHang);
        }
        public ActionResult CaVang(int page = 1, int pageSize = 6)
        {
            var listCaVang = objWebsiteCuaHang.Products
                .Where(n => n.IdGroupProduct == 1)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listCaVang);
        }

        public ActionResult LaHan(int page = 1, int pageSize = 6)
        {
            var listLaHan = objWebsiteCuaHang.Products
                .Where(n => n.IdGroupProduct == 2 )
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listLaHan);
        }

        public ActionResult Koi(int page = 1, int pageSize = 6)
        {
            var listKoi = objWebsiteCuaHang.Products
                .Where(n => n.IdGroupProduct == 3 )
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listKoi);
        }
        public ActionResult Guppy(int page = 1, int pageSize = 6)
        {
            var listGuppy = objWebsiteCuaHang.Products
                .Where(n => n.IdGroupProduct == 4)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listGuppy);
        }
        public ActionResult Betta(int page = 1, int pageSize = 6)
        {
            var listBetta = objWebsiteCuaHang.Products
                .Where(n => n.IdGroupProduct == 5 )
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listBetta);
        }
        

        
        
    }
}