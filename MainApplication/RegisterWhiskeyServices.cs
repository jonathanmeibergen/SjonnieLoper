using Microsoft.Extensions.DependencyInjection;
using SjonnieLoper.Services;

namespace SjonnieLoper
{
    public static class MyServices
    {
        public static IServiceCollection RegisterWhiskeyServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IReservations, Mock_Reservations>()
                .AddSingleton<IWhiskeys, Mock_Whiskey>();
        }
    }
}