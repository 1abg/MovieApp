using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Repositories.Base
{
    public interface IUnitOfWork
    {
        public IMovieRepository MovieRepository { get; }
        public IMovieNoteRepository MovieNoteRepository { get; }


        Task<int> CommitAsync();
        int Commit();

    }
}
