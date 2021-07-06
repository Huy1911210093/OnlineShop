namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
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
        public int IdProduct { get; set; }

        public int IdGroupProduct { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public double? Price { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        public double? PriceNew { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(100)]
        public string DVT { get; set; }

        public int? Status { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        public virtual GroupProduct GroupProduct { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
