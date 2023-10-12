using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.DATA.EF.Models//Metadata
{
    public class ProductMetada
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Product")]
        [StringLength(50)]
        public string? ProductName { get; set; }
        [Display(Name = "Product")]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string? ProductDescription { get; set; }
        public int? CategoryId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [Display(Name = "Price")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal? ProductPrice { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Available Units")]
        public int? UnitsInStock { get; set; }
        public int? RestockLevel { get; set; }

        public string? ProductImage { get; set; }
    }

    public class CategoryMetadata
    {
        [Required]
        [Display(Name = "Cetegory")]
        [StringLength(50)]
        public string? CategoryName { get; set; }
        [Display(Name = "Description")]
        [StringLength(500)]
        public string? CategoryDescription { get; set; }
    }

    public class CustomerMetadata
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string? CustomerEmail { get; set; }
        [StringLength(24, ErrorMessage = "Maximum 24 characters")]
        public string? PhoneNumber { get; set; }
    }

    public class RestockMetadata
    {
        [Display(Name = "Minimum Stock")]
        public int? MinStock { get; set; }
        [Display(Name = "Maximum Stock")]
        public int? MaxStock { get; set; }
    }

    public class ShippingInfoMetaData
    {
        [Required]
        [Display(Name = "Street Address")]
        [StringLength(50)]
        public string Street { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(2)]
        public string State { get; set; } = null!;
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }
    }
}
