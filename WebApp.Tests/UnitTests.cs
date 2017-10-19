using System;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.Services;
using System.Linq;

using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Tests
{
    public class UnitTests
    {
        private readonly IRepositoryService _reposvc;
        private readonly IPricingService _pricsvc;
        private ProductsController _controller;

        public UnitTests()
        {
            _reposvc = new MemoryRepositoryService();

            var mockDbService = new Mock<IPricingService>();
            mockDbService.SetReturnsDefault(50M);
            _pricsvc = mockDbService.Object;

            _controller = new ProductsController(_reposvc, _pricsvc);
        }

        [Fact]
        public void BadRequestPath()
        {
            var result = _controller.Get(1, null);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            var badResult = result as BadRequestObjectResult;

            Assert.Equal(400, badResult.StatusCode);
            Assert.Null(badResult.Value);
        }

        [Fact]
        public void NotFoundRequestPath()
        {
            var result = _controller.Get(999, "foo");

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);

            var notFoundResult = result as NotFoundObjectResult;

            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Null(notFoundResult.Value);
        }        
    }
}
