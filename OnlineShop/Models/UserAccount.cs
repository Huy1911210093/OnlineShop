namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Required]
        [DisplayName("Mã TK")]
        public int IdUser { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Họ")]
        [StringLength(500)]
        [DisplayName("Họ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Tên")]
        [StringLength(500)]
        [DisplayName("Tên")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        [StringLength(10)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(500, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDay { get; set; }
        [DisplayName("Trạng thái")]
        public int? Status { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

    }
}
