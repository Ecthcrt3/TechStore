using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class OrderInformation
    {
        public int OrderInformationId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order? Order { get; set; }
    }
}
