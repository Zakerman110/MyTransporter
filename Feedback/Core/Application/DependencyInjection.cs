using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Feedback.Core.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
        }
    }
}
