using FluentAssertions;
using Order.Tests.IntegrationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.Tests.IntegrationTests
{
    public class OrderControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        //private readonly ApiWebApplicationFactory _fixture;
        private readonly HttpClient _client;

        public OrderControllerTests(ApiWebApplicationFactory fixture)
        {
            //_fixture = fixture;

            dynamic data = new ExpandoObject();
            data.sub = Guid.NewGuid();
            data.role = new[] { "sub_role", "admin" };

            _client = fixture.CreateClient();
            _client.SetFakeBearerToken((object)data);
        }

        [Theory]
        [InlineData("api/order")]
        [InlineData("api/order/detail")]
        [InlineData("api/order/1")]
        public async Task GET_ReturnsPositiveStatusCode(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_ReturnsOrders()
        {
            var appFactory = new ApiWebApplicationFactory();
            dynamic data = new ExpandoObject();
            data.sub = Guid.NewGuid();
            data.role = new[] { "sub_role", "admin" };

            var newClient = appFactory.CreateClient();
            newClient.SetFakeBearerToken((object)data);

            var orders = await newClient.GetAndDeserialize<IEnumerable<DAL.Entities.Order>>("/api/order");
            orders.Should().HaveCount(3);
        }

        [Fact]
        public async Task Delete_RemainsTwoOrders()
        {
            await _client.DeleteAsync("/api/order/1");

            var orders = await _client.GetAndDeserialize<IEnumerable<DAL.Entities.Order>>("/api/order");
            orders.Should().HaveCount(2);
        }
    }
}
