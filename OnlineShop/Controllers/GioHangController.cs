using OnlineShop.Models;
using OnlineShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        private const string CartSession = "CartSesson";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {

            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.IdProduct == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.product.IdProduct == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.product = (Product)product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                //Tao moi doi tuong Cart
                var item = new CartItem();
                item.product = (Product)product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsionCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sesionCart = (List<CartItem>)Session[CartSession];
            foreach(var item in sesionCart)
            {
                var jsonItem = jsionCart.SingleOrDefault(x => x.product.IdProduct == item.product.IdProduct);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sesionCart;
            return Json(new
            {
                status = 1
            }) ;
        }
    }
}