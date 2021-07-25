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
            //chặn không cho ttruy cập vào captcha
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            


            routes.MapRoute(
            name: "GioHang",
            url: "gio-hang",
            defaults: new { Controller = "GioHang", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Search",
            url: "tim-kiem",
            defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "Register", action = "Register", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" } );

            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { Controller = "Login", action = "Login", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
            name: "Payment",
            url: "thanh-toan",
            defaults: new { controller = "GioHang", action = "Payment", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Add Cart",
            url: "them-gio-hang",
            defaults: new { Controller = "GioHang", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
             );
            routes.MapRoute(
            name: "Payment Success",
            url: "hoan-thanh",
            defaults: new { controller = "GioHang", action = "Success", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );


            routes.MapRoute(
           name: "Contact",
           url: "lien-he",
           defaults: new { Controller = "Contact", action = "Index", id = UrlParameter.Optional },
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
