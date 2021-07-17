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
        public int IdCustomer { get; set; }
        [DisplayName("Tổng tiền")]
        public double? TotalMoney { get; set; }
        [DisplayName("Ngày tạo đơn")]
        public DateTime? Date { get; set; }
        [DisplayName("Trang thái")]
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
