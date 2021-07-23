using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;
        public ProductDao()
        {
            db = new ShopDbContext();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.Date).Take(top).ToList();
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.IdProduct != productId && x.IdProduct == product.IdProduct).ToList();
        }
    
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
    
        public Product ViewDetail(long id)
        {

            return db.Products.Find(id);
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
          //  keyword = "Sil";
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var model = (from a in db.Products
                         join b in db.GroupProducts
                         on a.IdProduct equals b.IdGroupProduct
                         where a.Name.Contains(keyword) 
                         select new
                         {
                             CateMetaTitle = b.Status,
                             CateName = b.Name,
                             CreatedDate = a.Date,
                             ID = a.IdProduct,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.Size,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate= x.CreatedDate,
                             ID= x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = (decimal?)x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.IdProduct == categoryID).Count();
            var model = (from a in db.Products
                         join b in db.GroupProducts
                         on a.IdGroupProduct equals b.IdGroupProduct
                         where a.IdGroupProduct == categoryID
                         select new
                         {
                             CateMetaTitle = b.IdGroupProduct,
                             CateName = b.Name,
                             CreatedDate = a.Date,
                             ID = a.IdProduct,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.Size,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = (decimal?)x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}