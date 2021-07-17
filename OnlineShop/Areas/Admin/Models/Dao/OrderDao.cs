using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDetail GetById(int id)
        {
            return db.OrderDetails.SingleOrDefault(m => m.Order.IdOder == id);
        }
    }
}