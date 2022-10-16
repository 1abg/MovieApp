using AutoMapper;
using MediatR;
using MovieApp.Application.Features.Movies.Dtos;
using MovieApp.Application.Repositories.Base;
using MovieApp.Domain.Concrete;
using MovieApp.Infrastructure.Caching.Abstract;
using MovieApp.Infrastructure.Utilities;

namespace MovieApp.Application.Features.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<List<MovieDto>>
    {
        public int PageLength { get; set; }
        public int PageNumber { get; set; }


        public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<MovieDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICacheService _cacheService;
            private readonly IMapper _mapper;

            public GetMoviesQueryHandler(IUnitOfWork unitOfWork, ICacheService cacheService, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _cacheService = cacheService;
            }

            public async Task<List<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
            {
                var key = await _cacheService.GetValueAsync(CacheKeyUtil.GetKeyFromPageNumberAndLength("getMovies", request.PageNumber, request.PageLength));

                var movies = await _cacheService.GetOrAddAsync(key,
                    async () => (await _unitOfWork.MovieRepository.GetAllAsync(pageNumber: request.PageNumber, pageSize: request.PageLength)).ToList(), 
                    TimeSpan.FromHours(1));

                return _mapper.Map<List<Movie>, List<MovieDto>>(movies.ToList());
            }
        }
    }
}
