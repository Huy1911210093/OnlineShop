namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int IdContact { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(12)]
        public string Tel { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(300)]
        public string Content { get; set; }

        public int? Status { get; set; }
    }
}
