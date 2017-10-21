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
    public class MyFixture : IDisposable
    {
        public IRepositoryService reposvc { get; private set; }
        public IPricingService pricsvc { get; private set; }
        public ProductsController controller { get; private set; }

        public MyFixture()
        {
            reposvc = new MemoryRepositoryService();

            var mockDbService = new Mock<IPricingService>();
            mockDbService.SetReturnsDefault(50M);
            pricsvc = mockDbService.Object;

            controller = new ProductsController(reposvc, pricsvc);
        }

        public void Dispose()
        {
            // clean up!
        }
    }

    public class UnitTestsFixture : IClassFixture<MyFixture>
    {
        private readonly MyFixture _fixture;

        public UnitTestsFixture(MyFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void BadRequestPath()
        {
            var result = _fixture.controller.Get(1, null);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            var badResult = result as BadRequestObjectResult;

            Assert.Equal(400, badResult.StatusCode);
            Assert.Null(badResult.Value);
        }

        [Fact]
        public void NotFoundRequestPath()
        {
            var result = _fixture.controller.Get(999, "foo");

            Assert.NotNull(result);
            Assert.IsType<NotFoundObjectResult>(result);

            var notFoundResult = result as NotFoundObjectResult;

            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Null(notFoundResult.Value);
        }        

        [Fact]
        public void HappyPath()
        {           
            var result = _fixture.controller.Get(1, "foo");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<ProductItem>(okResult.Value);

            var okProductResult = okResult.Value as ProductItem;

            Assert.Equal("Samsung S7", okProductResult.Name);
            Assert.Equal(350M, okProductResult.Price);
        }

        [Theory]
        [InlineData("03aaa")]
        [InlineData("17abc")]
        [InlineData("99edf")]
        [InlineData("10edfddd")]
        [InlineData("20")]
        [InlineData("xxxxxxxxxxxx")]
        public void PricingService_Zero(string code)
        {
            var pricsvc = new PricingService();

            Assert.Equal(0M, pricsvc.DiscountPercentage(code));
        }

        [Theory]
        [InlineData("10aaa")]
        [InlineData("10abc")]
        [InlineData("10edf")]
        [InlineData("10rrr")]
        [InlineData("10tmp")]
        public void PricingService_Discount10(string code)
        {
            var pricsvc = new PricingService();

            Assert.Equal(10M, pricsvc.DiscountPercentage(code));
        }

        [Theory]
        [InlineData("20xxa")]
        [InlineData("20axx")]
        [InlineData("20xzx")]
        [InlineData("20xxx")]
        public void PricingService_Discount20Plus(string code)
        {
            var pricsvc = new PricingService();

            Assert.True(pricsvc.DiscountPercentage(code) > 20M);
        }
    }
}
