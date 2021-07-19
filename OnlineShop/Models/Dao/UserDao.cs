using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class UserDao
    {
        ShopDbContext db = null;
        public UserDao()
        {
            db = new ShopDbContext();
        }
        public UserAccount GetById(string Email)
        {
            return db.UserAccounts.SingleOrDefault(x => x.Email == Email);
        }
        public string Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.Email;
        }




        public int Login(string email, string passWord)
        {
            var result = db.UserAccounts.SingleOrDefault(m => m.Email == email);
            if (result == null)
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

        public bool Delete(string Email)
        {
            try
            {
                var user = db.UserAccounts.Find(Email);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CheckEmail(string Email)
        {
            return db.UserAccounts.Count(x => x.Email == Email) > 0;
        }

    }
}
