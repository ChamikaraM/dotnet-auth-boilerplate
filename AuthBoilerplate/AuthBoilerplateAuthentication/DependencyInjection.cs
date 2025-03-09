using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthBoilerplateAuthentication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            // Authentication (JWT) services will be configured here
            return services;
        }
    }
}
