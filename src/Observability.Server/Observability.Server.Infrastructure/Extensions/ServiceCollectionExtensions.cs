using Microsoft.EntityFrameworkCore;
using Observability.Server.Infrastructure.DbConfig;

namespace Observability.Server.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<ObservabilityAppDbContext>(options =>
            options.UseNpgsql(configurationManager.GetConnectionString("ObservabilityDb")));
    }
}