using Microsoft.Extensions.DependencyInjection;
using SjonnieLoper.Services;

namespace SjonnieLoper.Components.ServiceRegistration
{
    public static partial class MyServices
    {
        public static IServiceCollection RegisterWhiskeyServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IReservations, SqlReservationData>()
                .AddScoped<ISqlWhiskeys, SqlSqlWhiskeyData>()
                .AddScoped<ICacheWhiskey, CacheWhiskey>()
                .AddScoped<ICacheReservations, CacheReservation>();
        }
    }
}