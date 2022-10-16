using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieApp.Domain.Concrete;
using MovieApp.Persistence.Extensions;

namespace MovieApp.Persistence.Context
{
    public class MovieContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Config();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieNote> MovieNotes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
