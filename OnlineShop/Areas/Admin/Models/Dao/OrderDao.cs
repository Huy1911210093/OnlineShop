using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OnlineShop.Models.Dao
{
    public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDetail GetById(int id)
        {
            return db.OrderDetails.SingleOrDefault(m => m.IdOder == id);
        }

        public IEnumerable<Order> ListAllPaging(int page, int pageSize)
        {
            //truyền ra số bản ghi và số trang
            return db.Orders.OrderByDescending(m => m.IdOder).ToPagedList(page, pageSize);
        }
    }
}