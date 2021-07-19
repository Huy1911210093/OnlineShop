namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        [Key]
        [DisplayName("Mã liên hệ")]
        public int IdContact { get; set; }

        [StringLength(500)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(300)]
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Trang thái")]
        public int? Status { get; set; }
    }
}
