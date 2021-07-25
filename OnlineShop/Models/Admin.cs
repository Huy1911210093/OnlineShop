namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int Id { get => id; set => id = value; }
        private int id;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        [StringLength(300)]
        public string FirstName { get; set; }

        [StringLength(300)]
        public string LastName { get; set; }

        [StringLength(300)]
        public string Email { get; set; }

        [StringLength(300)]
        public string Password { get; set; }
        
    }
}
