using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OnlineShop.Areas.Admin.Models.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;

        public ProductDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.IdProduct;
        }
        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            //truyền ra số bản ghi và số trang
            return db.Products.OrderByDescending(m => m.Date).ToPagedList(page,pageSize);
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.IdProduct);
                product.Price = entity.Price;
                product.Name = entity.Name;
                product.Detail = entity.Detail;
                product.Size = entity.Size;
                product.Image = entity.Image;
                product.Status = entity.Status;
                product.Date = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
            
        }
        public Product getById(int id)
        {
            return db.Products.Find(id);
        }
        public int getCount()
        {
            return db.Products.Count();
        }
        public List<Product> GetByType(int typeid)
        {
            return db.Products.Where(m => m.GroupProduct.TypeId == typeid).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

    }
}