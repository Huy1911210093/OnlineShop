using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class AdminDao
    {
        ShopDbContext db = null;

        public AdminDao()
        {
            db = new ShopDbContext();
        }
        public Admin GetById(string email)
        {
            return db.Admins.SingleOrDefault(m => m.Email == email);
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Login(string email, string passWord)
        {
            var result = db.Admins.Count(m => m.Email == email && m.Password == passWord);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}