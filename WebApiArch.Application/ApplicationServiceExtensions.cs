using Microsoft.Extensions.DependencyInjection;
using WebApi.Repository;

namespace WebApiArch
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services.AddScoped<UsersBussiness, UsersBussiness>();
    }
}
