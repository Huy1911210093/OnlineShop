using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class CategoryDao
    {
        ShopDbContext db = null;
        public CategoryDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(GroupProduct category)
        {
            db.GroupProducts.Add(category);
            db.SaveChanges();
            return category.IdGroupProduct;
        }
        public List<GroupProduct> ListAll()
        {
            return db.GroupProducts.Where(x => x.Status == 1).ToList();
        }
        public GroupProduct ViewDetail(long id)
        {
            return db.GroupProducts.Find(id);
        }
    }
}