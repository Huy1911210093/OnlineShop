using Facebook;
using OnlineShop.Areas.Admin.Common;
using OnlineShop.Common;
using OnlineShop.Models;
using OnlineShop.Models.Dao;
using System;
using System.Configuration;
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
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
       
        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,last_name,id,email");
                string Email = me.Email;
                string FirstName = me.First_name;
                string LastName = me.Last_name;

                var user = new UserAccount();
                user.Email = Email;
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Status = 1;
                user.CreatedDay = DateTime.Now;
                var resultInsert = new UserDao().InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    var userSession = new UserAccount();
                    userSession.FirstName = user.FirstName;
                    userSession.IdUser = user.IdUser;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                }
            }
            return RedirectToAction("Index", "Home");
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
                    Session["FirstName"] = data.FirstOrDefault().FirstName;
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
