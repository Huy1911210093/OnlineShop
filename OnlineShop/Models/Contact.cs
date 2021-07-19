namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        [DisplayName("Mã liên hệ ")]
        public int IdContact { get; set; }

        [StringLength(300)]
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Trạng thái")]
        public int? Status { get; set; }
    }
}
