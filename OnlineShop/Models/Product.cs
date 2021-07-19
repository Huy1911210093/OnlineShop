namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DisplayName("Mã sp")]
        public int IdProduct { get; set; }
        [DisplayName("Mã nhóm sp")]
        public int IdGroupProduct { get; set; }

        [StringLength(500)]
        [DisplayName("Tên sp")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        public string Detail { get; set; }
        [DisplayName("Giá")]
        public double? Price { get; set; }

        [StringLength(300)]
        [DisplayName("Ảnh")]
        public string Image { get; set; }
        [DisplayName("Giá mới")]
        public double? PriceNew { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? Date { get; set; }
        [DisplayName("Trang thái")]
        public int? Status { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public virtual GroupProduct GroupProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
