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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Loc()
        {
            return View();
        }
    }
}