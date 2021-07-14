using OnlineShop.Models;
using OnlineShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContact();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string Name, String Email, String Phone, String Content)
        {
            var contact = new Contact();
            contact.Name = Name;
            contact.Email = Email;
            contact.Phone = Phone;
            contact.Content = Content;

            var id = new ContactDao().InsertContact(contact);
            if (id > 0)
                return Json(new
                {
                    Status = 1
                });
            else
                return Json(new
                {
                    Status = 0
                });

        }
    }
}
