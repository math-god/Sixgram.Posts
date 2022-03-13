using Microsoft.Extensions.DependencyInjection;
using Post.Core.Interfaces.Connection;
using Post.Core.Services;

namespace Post.Core.ServiceExtensions;

public static class ServiceProviderExtensions
{
    public static void AddConnection(this IServiceCollection services, string server, int port)
    {
        services.AddScoped<IConnectionService, ConnectionService>();
    }
}