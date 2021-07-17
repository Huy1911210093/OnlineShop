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
        public Admin GetByEmail(string email)
        {
            return db.Admins.SingleOrDefault(m => m.Email == email);
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public int Login(string email, string passWord)
        {
            var result = db.Admins.SingleOrDefault(m => m.Email == email);
            if(result == null)
            {
                return 0;//tai khoan khong ton tai
            }
            else
            {
                if (result.Password == passWord)
                {
                    return 1;//dung email dung pass
                }
                else
                {
                    return -1;//sai pass
                }
            }
        }
    }
}