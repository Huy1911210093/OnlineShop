using BotDetect.Web.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "RegisterCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(UserAccount model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckEmail(model.Email))
                {
                    ViewBag.Success = ("Email đã tồn tại");
                }
                else
                {
                    var user = new UserAccount();
                    user.IdUser = model.IdUser;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Phone = model.Phone;
                    user.Password = GetMD5(model.Password);
                    user.CreatedDay = DateTime.Now;
                    user.Status = 0;
                    var result = dao.Insert(user);
                    if (result != null)
                    {
                        ViewBag.Success = ("Đăng ký thành công");
                        model = new UserAccount();

                    }
                    else
                    {
                        ViewBag.Success = ("Đăng ký không thành công");
                    }
                }
                ModelState.Clear();

            }
            return View(model);

        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }

}
