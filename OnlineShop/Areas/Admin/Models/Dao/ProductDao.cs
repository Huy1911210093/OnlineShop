using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;

        public ProductDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.IdProduct;
        }
        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            //truyền ra số bản ghi và số trang
            return db.Products.OrderByDescending(m => m.Date).ToPagedList(page,pageSize);
        }

        public bool Update() 

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
            
        }
        public List<Product> GetByType(int typeid)
        {
            return db.Products.Where(m => m.GroupProduct.TypeId == typeid).ToList();
        }
    }
}