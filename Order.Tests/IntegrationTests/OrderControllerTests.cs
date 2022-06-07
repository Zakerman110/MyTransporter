using FluentAssertions;
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

        [Fact]
        public async Task GET_ReturnsOrders()
        {
            /*dynamic data = new ExpandoObject();
            data.sub = Guid.NewGuid();
            data.role = new[] { "sub_role", "admin" };

            using var client = _fixture.CreateClient();
            _client.SetFakeBearerToken((object)data);*/

            var response = await _client.GetAsync("api/order");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
