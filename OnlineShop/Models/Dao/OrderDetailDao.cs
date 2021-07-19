using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class OrderDetailDao
    {
        ShopDbContext db = null;
        public OrderDetailDao()
        {
            db = new ShopDbContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}