    using OnlineShop.Areas.Admin.Common;
using OnlineShop.Models;
using OnlineShop.Models.Dao;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class LoginController : Controller
    {
        ShopDbContext db = new ShopDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                var f_Password = GetMD5(Password);
                var dao = new UserDao();
                var data = db.UserAccounts.Where(s => s.Email.Equals(Email) && s.Password.Equals(f_Password)).ToList();

                if (data.Count() > 0)
                {
                    //add session
                    Session["IdUser"] = data.FirstOrDefault().IdUser;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["FistName"] = data.FirstOrDefault().FirstName;
                    Session["LastName"] = data.FirstOrDefault().LastName;
                    Session["Phone"] = data.FirstOrDefault().Phone;
                    Session["Password"] = Password;
                    Session["CreatedDay"] = data.FirstOrDefault().CreatedDay;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Success = "Tài khoản hoặc mật khẩu không đúng.";

                }

            }
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("Home");
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
