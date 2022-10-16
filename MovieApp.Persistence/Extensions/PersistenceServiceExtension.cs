using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Repositories;
using MovieApp.Persistence.Repositories;
using MovieApp.Application.Repositories.Base;
using MovieApp.Persistence.Repositories.Base.Ef.UnitOfWork;

namespace MovieApp.Persistence.Extensions
{
    public static class PersistenceServiceExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("MovieConnectionString")));

            services.AddScoped<IUnitOfWork, EfUnitOfWork<MovieContext>>();

            services.AddScoped<IMovieRepository, EfMovieRepository>();
            services.AddScoped<IMovieNoteRepository, EfMovieNoteRepository>();

            return services;
        }
    }
}
