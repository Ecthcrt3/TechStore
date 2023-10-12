using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class Restock
    {
        public Restock()
        {
            Products = new HashSet<Product>();
        }

        public int RestockLevel { get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
