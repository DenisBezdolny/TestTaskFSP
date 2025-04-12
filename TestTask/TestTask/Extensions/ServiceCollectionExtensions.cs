using TestTask.Bll.Services;
using TestTask.Domain.Entities;
using TestTask.Domain.Interfaces.Bll;
using TestTask.Domain.Interfaces.Repositories;
using TestTask.Infrastructure.Repositories;

namespace TestTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<User>>(provider => new Repository<User>(user => user.Id));
            services.AddScoped<IUserService,UserService>();

            return services;
        }
    }
}
