using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;

        public ProductDao()
        {
            db = new ShopDbContext();
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}