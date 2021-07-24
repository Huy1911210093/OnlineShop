using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Models
{
    [Table("ProductViewModel")]
    public partial class ProductViewModel
    {
        public long ID { set; get; }
        public string Images { set; get; }
        public string Name { set; get; }
        public decimal? Price { set; get; }
        public string CateName { set; get; }
        public string CateMetaTitle { set; get; }
        public string MetaTitle { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}