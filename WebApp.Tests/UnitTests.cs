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
        [Fact]
        public void BadRequestPath()
        {
            // Arrange                        
            var mockPricingService = new Mock<IPricingService>();
            mockPricingService
                //.SetReturnsDefault(0M);
                .Setup(a => a.DiscountPercentage(It.IsAny<string>()))
                .Returns(0M);

            var controller = new ProductsController(new MemoryRepositoryService(), mockPricingService.Object);

            // Act
            var result = controller.Get(1, null);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);

            var badResult = result as BadRequestObjectResult;

            Assert.Equal(400, badResult.StatusCode);
            Assert.Null(badResult.Value);
        }       
    }
}
