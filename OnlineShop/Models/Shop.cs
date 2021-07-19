namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public partial class Shop
    {
        [Key]
        [Column(Order = 0)]
        [DisplayName("Mã shop")]
        public int IdShop { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã vùng")]
        public int IdProvince { get; set; }

        [StringLength(500)]
        [DisplayName("Tên shop")]
        public string Name { get; set; }

        [StringLength(500)]
        [DisplayName("Địa chỉ shop")]
        public string Address { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        public virtual Province Province { get; set; }
    }
}
