using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public static class Constants
    {
        public static List<ProductItem> ProductItemList => new List<ProductItem> { 
            new ProductItem { Id = 1, Name = "Samsung S7", Price = 700 },
            new ProductItem { Id = 2, Name = "IPhone 8 Plus", Price = 900 },
            new ProductItem { Id = 3, Name = "Google Pixel 2XL", Price = 800 }
        };
    }
}
