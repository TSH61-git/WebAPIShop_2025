using Entities;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;
using TestProject;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class ProductRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly MyWebApiShopContext _context;
    private readonly ProductRepository _repository;

    public ProductRepositoryIntegrationTests(DatabaseFixture databaseFixture)
    {
        _context = databaseFixture.Context;
        _repository = new ProductRepository(_context);
    }

    [Fact]
    public async Task GetProducts_ProductsExist_ReturnsAllProducts()
    {
        // Arrange
        var product1 = new Product { ProductName = "Product1", Price = 10 };
        var product2 = new Product { ProductName = "Product2", Price = 20 };
        _context.Products.AddRange(product1, product2);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetProducts(new ProductSearchParams { });

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.ProductName == "Product1");
        Assert.Contains(result, p => p.ProductName == "Product2");
    }

    [Fact]
    public async Task GetProducts_NoProducts_ReturnsEmptyList()
    {
        // Act
        var result = await _repository.GetProducts(new ProductSearchParams { });

        // Assert
        Assert.Empty(result);
    }

}
