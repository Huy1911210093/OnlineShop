using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
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
        public IEnumerable<UserAccount> ListAllPaging(string search,int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;//phải convert sang kiểu này mới search được
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(m => m.Phone.Contains(search) || m.Email.Contains(search)); //contains: tìm gần đúng
            }

            //truyền ra số bản ghi và số trang
            return model.OrderByDescending(m => m.CreatedDay).ToPagedList(page, pageSize);
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
        public bool UpdateAdmin(Admin entity)
        {
            try
            {
                var admin = db.Admins.Find(entity.Id);
                admin.FirstName = entity.FirstName;
                admin.LastName = entity.LastName;
                admin.Email = entity.Email;
                admin.Password = entity.Password;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public Admin getByIdAdmin(int id)
        {
            return db.Admins.Find(id);
        }
        public UserAccount getByIdUser(int id)
        {
            return db.UserAccounts.Find(id);
        }
        public bool UpdateUser(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.IdUser);
                user.Email = entity.Email;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Phone = entity.Phone;
                user.Status = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int getCountUser()
        {
            return db.UserAccounts.Count();
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