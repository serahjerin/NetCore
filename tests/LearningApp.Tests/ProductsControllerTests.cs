using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using MediatR;
using LearningApp.API.Controllers;
using LearningApp.Core.DTOs;
using LearningApp.Core.Queries;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LearningApp.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ProductsController>> _loggerMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ProductsController>>();
            _controller = new ProductsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetProduct_WithValidId_ReturnsProduct()
        {
            // Arrange
            var productId = 1;
            var expectedProduct = new ProductDto
            {
                Id = productId,
                Name = "Test Product",
                Price = 10.99m,
                Stock = 5
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default))
                .ReturnsAsync(expectedProduct);

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var product = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(expectedProduct.Id, product.Id);
            Assert.Equal(expectedProduct.Name, product.Name);
        }

        [Fact]
        public async Task GetProduct_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var productId = 999;
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default))
                .ReturnsAsync((ProductDto?)null);

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProducts_ReturnsListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<ProductDto>
            {
                new() { Id = 1, Name = "Product 1", Price = 10.99m },
                new() { Id = 2, Name = "Product 2", Price = 15.99m }
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default))
                .ReturnsAsync(expectedProducts);

            // Act
            var result = await _controller.GetProducts(null, null, 1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Equal(2, products.Count());
        }
    }
}