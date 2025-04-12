﻿using TestTask.Domain.Interfaces.Repositories;
using TestTask.Infrastructure.Repositories;

namespace TestTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
