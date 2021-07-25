using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class GopYDao
    {
        ShopDbContext db = null;

        public GopYDao()
        {
            db = new ShopDbContext();
        }

        public bool Delete(int id)
        {
            try
            {
                var gopY = db.FeedBacks.Find(id);
                db.FeedBacks.Remove(gopY);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}