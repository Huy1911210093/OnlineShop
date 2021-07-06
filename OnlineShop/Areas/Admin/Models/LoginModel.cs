using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email không được bỏ trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password không được bỏ trống")]
        public string Password { get; set; }
    }
}