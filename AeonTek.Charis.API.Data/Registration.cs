using AeonTek.Charis.API.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AeonTek.Charis.API.Data
{
    public static class Registration
    {
        public static IServiceCollection AddCharisData(this IServiceCollection services, DatabaseType dbType, string connectionString)
        {
            switch (dbType)
            {
                case DatabaseType.Sqlite:
                    services.AddDbContext<IOrganizationContext, OrganizationContext>(options =>
                    {
                        options.UseLazyLoadingProxies().UseSqlite(connectionString);
                    });
                    break;
                case DatabaseType.Postgresql:

                    services.AddDbContext<IOrganizationContext, OrganizationContext>(options =>
                    {
                        options.UseLazyLoadingProxies().UseNpgsql(connectionString, builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), null));
                    });
                    break;
            }
            return services;
        }
    }
}
