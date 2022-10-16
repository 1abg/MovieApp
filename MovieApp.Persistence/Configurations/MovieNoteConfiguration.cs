using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Persistence.Configurations
{
    public class MovieNoteConfiguration : IEntityTypeConfiguration<MovieNote>
    {
        public void Configure(EntityTypeBuilder<MovieNote> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
