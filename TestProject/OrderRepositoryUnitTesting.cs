using Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Repository;


namespace TestProject
{
    public class OrderRepositoryUnitTesting
    {
        [Fact]
        public async Task AddOrder_AddsOrderSuccessfully()
        {
            // Arrange
            var users = new List<User>
            {
                new User {FirstName = "TestUser", Email = "testuser@example.com", Password= "1234" }
            };
            var products = new List<Product>
            {
                new Product { ProductId = 1, Price = 100m }
            };
            var orders = new List<Order>();

            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var mockLogger = new Mock<ILogger<OrderRepository>>(); 
            var repository = new OrderRepository(mockContext.Object, mockLogger.Object);

            var order = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 1 }
                },
                OrderSum = 100m,
                UserId = users[0].UserId
            };

            // Act
            var result = await repository.AddOrder(order);

            // Assert
            Assert.Equal(order, result);
        }

        [Fact]
        public async Task AddOrder_EmptyOrderItems_ShouldThrowException()
        {
            // Arrange
            var users = new List<User>
                {
                    new User {FirstName = "TestUser", Email = "testuser@example.com", Password = "123123" }
                };
            var orders = new List<Order>();

            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var mockLogger = new Mock<ILogger<UserRepository>>();
            var repository = new OrderRepository(mockContext.Object, mockLogger.Object);

            var order = new Order
            {
                OrderItems = new List<OrderItem>(), // ריק
                OrderSum = 0,
                UserId = users[0].UserId
            };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await repository.AddOrder(order);
            });

        }

        [Fact]
        public async Task AddOrder_ClientSumMatchesServerSum_PersistsOrderWithoutErrorLog()
        {
            // Arrange
            var users = new List<User>
            {
                new User {FirstName = "TestUser", Email = "testuser@example.com", Password= "1234" }
            };
            var products = new List<Product>
            {
                new Product { ProductId = 1, Price = 10m },
                new Product { ProductId = 2, Price = 20m }
            };
            var orders = new List<Order>();

            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var mockLogger = new Mock<ILogger<UserRepository>>();
            var repository = new OrderRepository(mockContext.Object, mockLogger.Object);

            var order = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2 },
                    new OrderItem { ProductId = 2, Quantity = 1 }
                },
                OrderSum = 40m,
                UserId = users[0].UserId
            };

            // Act
            var result = await repository.AddOrder(order);

            // Assert
            Assert.Equal(40m, result.OrderSum);
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Never);
        }

        [Fact]
        public async Task AddOrder_ClientSumMismatch_LogsErrorAndCorrectsOrderSum()
        {
            // Arrange
            var users = new List<User>
            {
                new User {FirstName = "TestUser", Email = "testuser@example.com", Password= "1234" }
            };
            var products = new List<Product>
            {
                new Product { ProductId = 1, Price = 10m },
                new Product { ProductId = 2, Price = 20m }
            };
            var orders = new List<Order>();

            var mockContext = new Mock<MyWebApiShopContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);

            var mockLogger = new Mock<ILogger<UserRepository>>();
            var repository = new OrderRepository(mockContext.Object, mockLogger.Object);

            var order = new Order
            {
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, Quantity = 2 },
                    new OrderItem { ProductId = 2, Quantity = 1 }
                },
                OrderSum = 1m,
                UserId = users[0].UserId
            };

            // Act
            var result = await repository.AddOrder(order);

            // Assert
            Assert.Equal(40m, result.OrderSum);
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception?>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

    }
}
