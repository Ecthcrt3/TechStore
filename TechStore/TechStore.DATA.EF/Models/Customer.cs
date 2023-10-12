using System;
using System.Collections.Generic;

namespace TechStore.DATA.EF.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
