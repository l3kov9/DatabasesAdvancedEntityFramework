﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? SellerId { get; set; }

        public User Seller { get; set; }

        public List<CategoryProduct> Categories { get; set; } = new List<CategoryProduct>();
    }
}
