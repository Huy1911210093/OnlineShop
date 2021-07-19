using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{

    public class PhuKienController : Controller
    {
        // GET: PhuKien
        ShopDbContext objwebsitePhuKien = new ShopDbContext();
        public ActionResult Index()
        {
            var lstPhuKien = objwebsitePhuKien.Products.Where(n => n.GroupProduct.TypeId == 2).ToList();
            return View(lstPhuKien);
        }
        public ActionResult Loc()
        {
            var listLoc = objwebsitePhuKien.Products.Where(n => n.IdGroupProduct == 6).ToList();
            return View(listLoc);
        }
        public ActionResult TrangTri()
        {
            var listTrangTri = objwebsitePhuKien.Products.Where(n => n.IdGroupProduct == 9).ToList();
            return View(listTrangTri);

        }
        public ActionResult ChePhamNuoc()
        {
            var listChePhamNuoc = objwebsitePhuKien.Products.Where(n => n.IdGroupProduct == 8).ToList();
            return View(listChePhamNuoc);
        }
        public ActionResult ThietBiChieuSang()
        {
            var listThietBiChieuSang = objwebsitePhuKien.Products.Where(n => n.IdGroupProduct == 7).ToList();
            return View(listThietBiChieuSang);
        }
    }
}