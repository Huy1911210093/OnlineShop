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
        [DisplayName("Nhóm sp")]
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

        private int typeId;

        public int GetTypeId()
        {
            return typeId;
        }

        public void SetTypeId(int value)
        {
            typeId = value;
        }

        [DisplayName("Mã loại")]
        public int? TypeId { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
