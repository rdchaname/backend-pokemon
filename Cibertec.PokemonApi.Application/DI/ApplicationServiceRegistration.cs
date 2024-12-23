using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cibertec.PokemonApi.Application.DI
{
    public static class ApplicationServiceRegistration
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => {
                x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            return services;
        }

    }
}
