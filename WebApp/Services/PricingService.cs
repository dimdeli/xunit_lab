using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class PricingService : IPricingService
    {
        public decimal GetDiscount(string userId)
        {
            switch (userId)
            {
                case "PLAISIO":
                    return 10M;
                case "PUBLIC":
                    return 8.5M;
                default:
                    return 0M;
            }
        }
    }
}
