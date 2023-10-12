using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderInformations = new HashSet<OrderInformation>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderTotal { get; set; }

        public virtual ICollection<OrderInformation> OrderInformations { get; set; }
    }
}
