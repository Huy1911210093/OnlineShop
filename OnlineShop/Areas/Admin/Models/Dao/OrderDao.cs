using OnlineShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class OrderDao
    {
        ShopDbContext db = null;
        public OrderDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<Order> ListAllPaging(string search,int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;//phải convert sang kiểu này mới search được
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(m => m.ShipName.Contains(search) || m.Date.ToString().Contains(search)); //contains: tìm gần đúng
            }

            //truyền ra số bản ghi và số trang
            return model.OrderByDescending(m => m.Date).ToPagedList(page, pageSize);
        }
        public long Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity.IdOder;
        }
        public bool Delete(int id)
        {
            try
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        //public int 

        public bool Update(Order entity)
        {
            try
            {
                var order = db.Orders.Find(entity.IdOder);
                order.Status = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Order getById(int id)
        {
            return db.Orders.Find(id);
        }
        public int getCount()
        {
            return db.Orders.Count();
        }
    }
}