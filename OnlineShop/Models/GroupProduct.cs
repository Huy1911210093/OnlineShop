namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupProduct")]
    public partial class GroupProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupProduct()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DisplayName("Mã nhóm sp")]
        public int IdGroupProduct { get; set; }

        [StringLength(500)]
        [DisplayName("Tên nhóm")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        public string Content { get; set; }

        [StringLength(300)]
        [DisplayName("Ảnh")]
        public string Images { get; set; }
        [DisplayName("Trang thái")]
        public int? Status { get; set; }

        [StringLength(100)]
        [DisplayName("Đơn vị tính")]
        public string DVT { get; set; }
<<<<<<< HEAD
        public int TypeId { get; set; }


=======
        [DisplayName("Mã loại")]
        public int? TypeId { get; set; }
>>>>>>> 53b41ce55fef70b8a39aedc35890a28106c09d19

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
