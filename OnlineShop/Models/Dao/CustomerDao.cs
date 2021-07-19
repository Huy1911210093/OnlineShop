using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class CustomerDao
    {
        ShopDbContext db = null;
        public CustomerDao()
        {
            db = new ShopDbContext();
        }
        public int Insert(UserAccount customer)
        {
            db.UserAccounts.Add(customer);
            db.SaveChanges();
            return customer.IdUser;
        }
    }
}