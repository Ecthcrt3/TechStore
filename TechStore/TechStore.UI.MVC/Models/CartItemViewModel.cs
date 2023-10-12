﻿using TechStore.DATA.EF.Models;

namespace TechStore.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }
        public Product Product { get; set; }
        public CartItemViewModel(int qty, Product product)
        {
            Qty = qty;
            Product = product;
        }

    }
}
