namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DisplayName("Mã đơn hàng")]
        public int IdOder { get; set; }
        [DisplayName("Mã KH")]
        public int IdUserAccount { get; set; }

        [StringLength(500)]
        [DisplayName("Tên liên hệ")]
        public string ShipName { get; set; }

        [StringLength(10)]
        [DisplayName("SDT liên hệ")]
        public string ShipMobile { get; set; }

        [StringLength(500)]
        [DisplayName("Địa chỉ liên hệ")]
        public string ShipAddress { get; set; }

        [StringLength(300)]
        [DisplayName("Email")]
        public string ShipEmail { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? Date { get; set; }
        [DisplayName("Trạng thái")]
        public int? Status { get; set; }
        [DisplayName("Phương thức thanh toán")]
        public int? PaymentMethod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
