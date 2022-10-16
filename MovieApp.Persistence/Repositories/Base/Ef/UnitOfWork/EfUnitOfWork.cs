using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Repositories;
using MovieApp.Application.Repositories.Base;
using MovieApp.Persistence.Context;

namespace MovieApp.Persistence.Repositories.Base.Ef.UnitOfWork
{
    public class EfUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        public IMovieRepository _movieRepository { get; private set; }
        public IMovieNoteRepository _movieNoteRepository { get; private set; }


        public EfUnitOfWork(TContext context)
        {
            _context = context;
        }

        public IMovieRepository MovieRepository
        {
            get { return _movieRepository = _movieRepository ?? new EfMovieRepository(_context as MovieContext); }
        }

        public IMovieNoteRepository MovieNoteRepository
        {
            get { return _movieNoteRepository = _movieNoteRepository ?? new EfMovieNoteRepository(_context as MovieContext); }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}