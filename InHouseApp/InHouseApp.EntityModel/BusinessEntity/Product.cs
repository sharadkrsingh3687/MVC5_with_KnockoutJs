using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InHouseApp.EntityModel.BusinessEntity
{
    public class Product : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ProductID { get; set; }

        [Required (ErrorMessage ="SKU Number is required")]
        [StringLength (10, MinimumLength =6, ErrorMessage ="SKU Number should be 6 to 10")]
        public string SKUNumber { get; set; }

        [Required (ErrorMessage = "Product Name is required")]
        [StringLength (100, ErrorMessage = "Product Name should be less than 100 character")]
        public string ProductName { get; set; }

        [Required (ErrorMessage = "Product Type is required")]
        [StringLength (100, ErrorMessage = "Product type should be less than 100 character")]
        public string ProductType { get; set; }
        public string ProductDesc { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public int StarRating { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}
