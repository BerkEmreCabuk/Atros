using Atros.Common.Models;
using Atros.Domain.Movies.Models;
using Atros.Domain.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Atros.Domain.MovieEvaluations.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Atros.Domain.MovieEvaluations.Commands;
using Microsoft.Extensions.Caching.Memory;
using System;
using Atros.Domain.Users.Models;
using Atros.Domain.MovieEvaluations.Queries;

namespace Atros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMemoryCache _memory;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        public MovieController(
            IMemoryCache memory
            )
        {
            _memory = memory;
        }

        [HttpGet("paging")]
        public async Task<ActionResult<PagedList<MoviePagedModel>>> Get(int pageSize, int pageIndex)
        {
            return Ok(await Mediator.Send(new GetPagedMovieModelQuery { PageSize = pageSize, PageIndex = pageIndex }));
        }

        [HttpGet("getdetail")]
        public async Task<ActionResult<MoviePagedModel>> GetDetail(int movieId)
        {
            if (!Request.Headers.TryGetValue("Authorization", out var key))
                throw new Exception("Authorization bilgisi bulunamamaktadır.");

            var keyString = key.ToString().Replace("Bearer ", "");
            if (!_memory.TryGetValue(keyString, out UserModel user))
                throw new Exception("Kullanıcı bilgisi bulunamamaktadır.");

            return Ok(await Mediator.Send(new GetMovieWithDetailQuery { MovieId = movieId, UserId = user.Id }));
        }

        [HttpGet("advice")]
        public async Task<ActionResult<PagedList<MoviePagedModel>>> Advice(string emailAddress, int movieId)
        {
            return Ok(await Mediator.Send(new AdviseMovieByMailQuery { EmailAddress = emailAddress, MovieId = movieId }));
        }

        [HttpPost("commentwithscore")]
        public async Task<IActionResult> CommentWithScore([FromBody]MovieEvaluationModel movieEvaluationModel)
        {
            if (!Request.Headers.TryGetValue("Authorization", out var key))
                throw new Exception("Authorization bilgisi bulunamamaktadır.");

            var keyString = key.ToString().Replace("Bearer ", "");
            if (!_memory.TryGetValue(keyString, out UserModel user))
                throw new Exception("Kullanıcı bilgisi bulunamamaktadır.");
            movieEvaluationModel.UserId = user.Id;

            return Created("", await Mediator.Send(new PostMovieEvaluationCommand { MovieEvaluationModel = movieEvaluationModel }));
        }
    }
}