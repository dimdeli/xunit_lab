using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class ProductItem
    {
        private decimal price_;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price
        {
            get { return price_ * ((100 - DiscountPercentage) / 100); }
            set { price_ = value; }
        }

        public decimal DiscountPercentage { get; set; }
    }
}
