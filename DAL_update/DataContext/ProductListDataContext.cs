﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Data
{
    public class ProductListContext: ListContext<ProductEntity>
    {
        public ProductListContext()
        {
            DataList = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = 1,
                    Name = "Fanta",
                    Category = "drinks",
                    Price = 19.90M
                },
                new ProductEntity
                {
                    Id = 2,
                    Name = "Strite",
                    Category = "drinks",
                    Price = 29.90M
                },
                new ProductEntity
                {
                    Id = 3,
                    Name = "Banana",
                    Category = "fruits",
                    Price = 67.20M
                },
                new ProductEntity
                {
                    Id = 4,
                    Name = "Apple",
                    Category = "fruits",
                    Price = 17.10M
                },
                new ProductEntity
                {
                    Id = 5,
                    Name = "Potato",
                    Category = "vegetables",
                    Price = 12.50M
                },
                new ProductEntity
                {
                    Id = 6,
                    Name = "Tomato",
                    Category = "vegetables",
                    Price = 56.40M
                }
            };
        }
    }
}