using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository;
using Repository.Models;

namespace TestProject
{
    public class CategoryRepositoryIntegrationTests : IClassFixture<DatabaseFixture>, IDisposable
    {
        private readonly MyWebApiShopContext _context;
        private readonly CategoryRepository _repository;
        private IDbContextTransaction _transaction;

        public CategoryRepositoryIntegrationTests(DatabaseFixture fixture)
        {
            _context = fixture.Context;
            _repository = new CategoryRepository(_context);

            _transaction = _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        [Fact]
        public async Task GetCategories_ReturnsAllCategories()
        {
            // Arrange
            var category1 = new Category { CategoryName = "Category 1" };
            var category2 = new Category { CategoryName = "Category 2" };

            _context.Categories.AddRange(category1, category2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.CategoryName == "Category 1");
            Assert.Contains(result, c => c.CategoryName == "Category 2");
        }

        [Fact]
        public async Task GetCategories_EmptyTable_ReturnsEmptyList()
        {
            // Arrange
            _context.Categories.RemoveRange(_context.Categories);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
