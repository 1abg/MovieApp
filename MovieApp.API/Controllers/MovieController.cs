using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.MessageQueue;
using MovieApp.API.Models;
using MovieApp.Application.Features.Movies.Commands.AddNoteAndPointToMovie;
using MovieApp.Application.Features.Movies.Dtos;
using MovieApp.Application.Features.Movies.Queries.GetMovieById;
using MovieApp.Application.Features.Movies.Queries.GetMovies;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMediator _mediator;
        private readonly IMessageQueueProducer _messageQueueProducer;

        public MovieController(IMediator mediator, IMessageQueueProducer messageQueueProducer)
        {
            _mediator = mediator;
            _messageQueueProducer = messageQueueProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery getMoviesQuery)
        {
            var movies = await _mediator.Send(getMoviesQuery);
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById([FromQuery] GetMovieByIdQuery getMovieByIdQuery)
        {
            var movie = await _mediator.Send(getMovieByIdQuery);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieInfo(AddNoteAndPointToMovieCommand addNoteAndPointToMovieCommand)
        {
            await _mediator.Send(addNoteAndPointToMovieCommand);
            return Ok();
        }

        [HttpGet("RecommendMovie")]
        public async Task<IActionResult> RecommendMovie(string id, string email)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery { Id = Guid.Parse(id) });
            var mailSendModel = new MailSendModel<MovieDto> { Email = email, Data = movie };
            _messageQueueProducer.SendMessage<MailSendModel<MovieDto>>("mailing", mailSendModel);
            return Ok();
        }
    }
}