using MovieApp.Application.Repositories;
using MovieApp.Domain.Concrete;
using MovieApp.Persistence.Context;
using MovieApp.Persistence.Repositories.Base.Ef.Repository;

namespace MovieApp.Persistence.Repositories
{
    public class EfMovieNoteRepository : EfRepository<MovieNote, MovieContext>, IMovieNoteRepository
    {
        public EfMovieNoteRepository(MovieContext context) : base(context)
        {
        }
    }
}
