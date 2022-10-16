using AutoMapper;
using MovieApp.Application.Features.Movies.Commands.AddNoteAndPointToMovie;
using MovieApp.Application.Features.Movies.Dtos;
using MovieApp.Domain.Concrete;

namespace MovieApp.Application.Features.Movies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<AddNoteAndPointToMovieCommand, MovieNote>();
        }
    }
}
