using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDao()
        {
            db = new ShopDbContext();
        }
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.IdOder;
        }
    }
}