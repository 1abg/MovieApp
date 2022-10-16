using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Repositories;
using MovieApp.Domain.Concrete;
using MovieApp.Persistence.Context;
using MovieApp.Persistence.Repositories.Base.Ef.Repository;

namespace MovieApp.Persistence.Repositories
{
    public class EfMovieRepository : EfRepository<Movie, MovieContext>, IMovieRepository
    {
        public EfMovieRepository(MovieContext context) : base(context)
        {
        }
    }
}
