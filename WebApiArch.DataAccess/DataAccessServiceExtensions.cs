using Microsoft.Extensions.DependencyInjection;

using WebApi.Interfaces;
using WebApi.Repository;

namespace WebApi
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddWebApiRepositories(this IServiceCollection services)
            => services.AddScoped<IUsersRepository, UsersRepository>();
    }
}
