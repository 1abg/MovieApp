using AutoMapper;
using MediatR;
using MovieApp.Application.Repositories.Base;
using MovieApp.Domain.Concrete;

namespace MovieApp.Application.Features.Movies.Commands.AddNoteAndPointToMovie
{
    public class AddNoteAndPointToMovieCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public int Score { get; set; }



        public class AddNoteAndPointToMovieCommandHandler : IRequestHandler<AddNoteAndPointToMovieCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public AddNoteAndPointToMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(AddNoteAndPointToMovieCommand request, CancellationToken cancellationToken)
            {
                var movieNote = _mapper.Map<AddNoteAndPointToMovieCommand, MovieNote>(request);
                await _unitOfWork.MovieNoteRepository.AddAsync(movieNote);
                await _unitOfWork.CommitAsync();
                return Unit.Value;
            }
        }
    }
}
