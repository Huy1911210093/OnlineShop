using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class ProductCategoryDao
    {
        ShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopDbContext();
        }
        public List<GroupProduct> ListAll()
        {
            return db.GroupProducts.Where(x => x.Status == 1).OrderBy(x => x.Name).ToList();
        }

        public GroupProduct ViewDetail(int id)
        {
            return db.GroupProducts.Find(id);
        }
    
    }
}