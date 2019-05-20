using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class MemoryRepositoryService : IRepositoryService
    {
        public IList<ProductItem> GetAll()
        {
            return Constants.ProductItemList;
        }

        public ProductItem Get(int id)
        {
            return Constants.ProductItemList.SingleOrDefault(i => i.Id == id);
        }
    }
}
