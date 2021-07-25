using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace OnlineShop.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        ShopDbContext objWebsiteProduct = new ShopDbContext();
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebsiteProduct.Products.Where(n => n.IdProduct == Id).Take(1).ToList();
            return View(objProduct);

        }
       
    }
}