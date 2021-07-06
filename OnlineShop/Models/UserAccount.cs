namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [Key]
        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(500)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDay { get; set; }

        public int? Status { get; set; }
    }
}
