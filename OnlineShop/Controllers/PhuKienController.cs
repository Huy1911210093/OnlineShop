using OnlineShop.Models;
using PagedList;
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
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var lstPhuKien = objwebsitePhuKien.Products
                .Where(p => p.GroupProduct.TypeId == 2)
                .OrderBy(p => p.GroupProduct.TypeId)
                .ToPagedList(page, pageSize);
            return View(lstPhuKien);
        }
        public ActionResult Loc(int page = 1, int pageSize = 6)
        {
            var listLoc = objwebsitePhuKien.Products
                .Where(n => n.IdGroupProduct == 6)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listLoc);
        }

        public ActionResult ThietBiChieuSang(int page = 1, int pageSize = 6)
        {
            var listThietBiChieuSang = objwebsitePhuKien.Products
                .Where(n => n.IdGroupProduct == 7)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listThietBiChieuSang);
        }


        public ActionResult ChePhamNuoc(int page = 1, int pageSize = 6)
        {
            var listChePhamNuoc = objwebsitePhuKien.Products
                .Where(n => n.IdGroupProduct == 8)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listChePhamNuoc);
        }

        public ActionResult TrangTri(int page = 1, int pageSize = 6)
        {
            var listTrangTri = objwebsitePhuKien.Products
                .Where(n => n.IdGroupProduct == 9)
                .OrderBy(n => n.IdGroupProduct)
                .ToPagedList(page, pageSize);
            return View(listTrangTri);
        }
       
        
    }
}