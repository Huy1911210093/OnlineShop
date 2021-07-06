using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}