using DTOs;
using Entities;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;
using Repository.Models;

namespace TestProject
{
    public class ProductRepositoryUnitTesting
    {
        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product 1" },
            new Product { ProductId = 2, ProductName = "Product 2" }
        };

            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repository = new ProductRepository(mockContext.Object);

            // Act
            var result = await repository.GetProducts(new ProductSearchParams { });

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.ProductName == "Product 1");
            Assert.Contains(result, p => p.ProductName == "Product 2");
        }

        [Fact]
        public async Task GetProducts_EmptyTable_ReturnsEmptyList()
        {
            // Arrange
            var products = new List<Product>();
            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repository = new ProductRepository(mockContext.Object);

            // Act
            var result = await repository.GetProducts(new ProductSearchParams { });

            // Assert
            Assert.Empty(result);
        }
    }
}
