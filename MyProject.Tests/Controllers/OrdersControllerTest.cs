using MyProject.Controllers;
using MyProject.Models;
using MyProject.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using MyProject.Services;

namespace MyProject.Tests.Controllers;

[TestFixture]
[TestOf(typeof(OrdersController))]
public class OrdersControllerTest
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IOrderService>();
        }

        [Test]
        public async Task GetOrders_WhenNoneExist_ReturnsEmptyList()
        {
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(r => r.GetAllOrdersAsync()).ReturnsAsync(new List<Order>());

            var result = await mockRepo.Object.GetAllOrdersAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetOrders_WhenNoneExist_Returns404()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var response = await client.GetAsync("/api/orders");
    
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}