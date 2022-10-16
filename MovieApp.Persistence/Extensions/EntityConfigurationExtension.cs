using Microsoft.EntityFrameworkCore;
using MovieApp.Persistence.Configurations;

namespace MovieApp.Persistence.Extensions
{
    public static class EntityConfigurationExtension
    {
        public static void Config(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieNoteConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
