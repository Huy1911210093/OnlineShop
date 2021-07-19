namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã sp")]
        public int IdProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã đơn hàng")]
        public int IdOder { get; set; }
        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }
        [DisplayName("Tổng tiền")]
        public long? TotalMoney { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
