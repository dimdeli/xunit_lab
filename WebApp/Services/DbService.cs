using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class DbService : IDbService
    {
        public ProductItem GetProductItem(int id)
        {
            return Constants.ProductItemList.SingleOrDefault(i => i.Id == id);
        }
    }
}
