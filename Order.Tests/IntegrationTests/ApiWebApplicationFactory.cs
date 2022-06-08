using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WebMotions.Fake.Authentication.JwtBearer;

namespace Order.Tests.IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => { });
            builder.ConfigureTestServices(services => {
                services.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddFakeJwtBearer();
            });
        }
    }
}
