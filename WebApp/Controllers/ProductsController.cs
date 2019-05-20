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
        private readonly IRepositoryService _reposvc;
        private readonly IPricingService _pricsvc;

        public ProductsController(IRepositoryService reposvc, IPricingService pricsvc)
        {
            _reposvc = reposvc;
            _pricsvc = pricsvc;
        }

        // GET api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _reposvc.GetAll();

            return Ok(products);
        }

        // GET api/products/1?code=12abc
        [HttpGet("{id}")]
        public IActionResult Get(int id, string code)
        {
            var product = default(ProductItem);

            if (string.IsNullOrWhiteSpace(code)) {
                return BadRequest(product);
            }

            product = _reposvc.Get(id);

            if (product == null) {
                return NotFound(product);
            }

            product.DiscountPercentage = _pricsvc.DiscountPercentage(code);

            return Ok(product);
        }
    }
}
