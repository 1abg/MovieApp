using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MovieApp.Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
