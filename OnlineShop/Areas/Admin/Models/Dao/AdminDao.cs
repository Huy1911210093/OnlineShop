using PagedList;
using PagedList.Mvc;
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
        public IEnumerable<UserAccount> ListAllPaging(int page, int pageSize)
        {
            //truyền ra số bản ghi và số trang
            return db.UserAccounts.OrderByDescending(m => m.CreatedDay).ToPagedList(page, pageSize);
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.GetId();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

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