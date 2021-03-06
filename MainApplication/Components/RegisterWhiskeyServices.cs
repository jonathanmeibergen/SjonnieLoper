﻿using Microsoft.Extensions.DependencyInjection;
using SjonnieLoper.Services;

namespace SjonnieLoper.Services
{
    public static class MyServices
    {
        public static IServiceCollection RegisterWhiskeyServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IReservations, SqlReservationData>()
                .AddScoped<IWhiskeys, SqlWhiskeyData>();
        }
    }
}