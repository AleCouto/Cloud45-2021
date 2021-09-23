﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int Amount { get; set; }

        [StringLength(120, MinimumLength = 3)]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public string ImgFotoProduct { get; set; }

        public IList<Order> Order { get; set; }

        public Product()
        {
        }

        public Product(int productId, string name, int amount)
        {
            ProductId = productId;
            Name = name;
            Amount = amount;
        }

        public Product(int productId, string name, int amount, string description, Category category)
        {
            ProductId = productId;
            Name = name;
            Amount = amount;
            Category = category;
        }
    }
}
