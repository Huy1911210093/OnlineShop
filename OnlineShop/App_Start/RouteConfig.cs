using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { Controller = "GioHang", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Add Cart",
            url: "them-gio-hang",
            defaults: new { Controller = "GioHang", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
    );

               routes.MapRoute(
                name:"Default",
                url:"{controller}/{action}/{id}",
                defaults:new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new[] { "OnlineShop.Controllers" }

            );
            routes.MapRoute(
                name: "Admin",
                url: "{controllers}/{action}/{id}",
                defaults: new { action = "Home", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Areas.Admin.Controllers" }
            );
        }
    }
}
