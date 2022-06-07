using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.Tests.IntegrationTests
{
    public class OrderControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _fixture;

        public OrderControllerTests(ApiWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GET_ReturnsOrders()
        {
            using var client = _fixture.CreateClient();

            var response = await client.GetAsync("");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
