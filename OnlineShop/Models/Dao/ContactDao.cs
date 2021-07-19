using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class ContactDao
    {
        ShopDbContext db = null;
        public ContactDao()
        {
            db = new ShopDbContext();
        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == 1);
        }
        public int InsertContact(Contact ct)
        {
            db.Contacts.Add(ct);
            db.SaveChanges();
            return ct.IdContact;
        }
    }
}

   




