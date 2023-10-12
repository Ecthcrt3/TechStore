using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class ShippingInfo
    {
        public int ShippingId { get; set; }
        public int? CustomerId { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? Zip { get; set; }
        public bool? IsPrimaryAddress { get; set; }
    }
}
