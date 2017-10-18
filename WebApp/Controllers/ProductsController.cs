using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IDbService _dbsvc;
        private readonly IPricingService _pricsvc;

        public ProductsController(IDbService dbsvc, IPricingService pricsvc)
        {
            _dbsvc = dbsvc;
            _pricsvc = pricsvc;
        }

        // GET api/products/1?code=12abc
        [HttpGet("{id}")]
        public IActionResult Get(int id, string code)
        {
            var product = default(ProductItem);

            if(code == null) {
                return BadRequest(product);
            }

            product = _dbsvc.GetProductItem(id);

            if (product == null) {
                return NotFound(product);
            }

            product.DiscountPercentage = _pricsvc.GetDiscount(code);

            return Ok(product);
        }
    }
}
