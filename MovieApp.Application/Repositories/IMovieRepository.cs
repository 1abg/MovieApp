using MovieApp.Application.Repositories.Base;
using MovieApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
}
