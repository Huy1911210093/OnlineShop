namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
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
        public int IdOder { get; set; }

        public int IdUserAccount { get; set; }

        [StringLength(500)]
        public string ShipName { get; set; }

        [StringLength(10)]
        public string ShipMobile { get; set; }

        [StringLength(500)]
        public string ShipAddress { get; set; }

        [StringLength(300)]
        public string ShipEmail { get; set; }

        public DateTime? Date { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
