using Microsoft.Extensions.DependencyInjection;

namespace AuthBoilerplateApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application-level services here
            return services;
        }
    }
}
