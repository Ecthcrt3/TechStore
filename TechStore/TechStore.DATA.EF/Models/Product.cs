using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryId { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? RestockLevel { get; set; }
        public string? ProductImage { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Restock? RestockLevelNavigation { get; set; }
    }
}
