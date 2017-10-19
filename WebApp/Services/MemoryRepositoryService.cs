using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class MemoryRepositoryService : IRepositoryService
    {
        public ProductItem GetProductItem(int id)
        {
            return Constants.ProductItemList.SingleOrDefault(i => i.Id == id);
        }
    }
}
