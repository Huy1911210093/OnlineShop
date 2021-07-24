using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Models
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<GroupProduct> GroupProducts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserActivation> UserActivations { get; set; }
        public virtual DbSet<ProductViewModel> ProductViewModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.UserAccount)
                .HasForeignKey(e => e.IdUserAccount)
                .WillCascadeOnDelete(false);
        }

        //public System.Data.Entity.DbSet<OnlineShop.Models.ProductViewModel> ProductViewModels { get; set; }
    }
}
