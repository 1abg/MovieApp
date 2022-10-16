using AutoMapper;
using MediatR;
using MovieApp.Application.Features.Movies.Dtos;
using MovieApp.Application.Repositories;
using MovieApp.Domain.Concrete;

namespace MovieApp.Application.Features.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<MovieDto>
    {
        public Guid Id { get; set; }


        public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
        {
            private readonly IMovieRepository _movieRepository;
            private readonly IMapper _mapper;

            public GetMovieByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper)
            {
                _movieRepository = movieRepository;
                _mapper = mapper;
            }

            public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
            {
                var movie = await _movieRepository.GetByIdAsync(request.Id);
                return _mapper.Map<Movie, MovieDto>(movie);
            }
        }
    }
}
