using AutoMapper;
using Library.Application.Features.Films.Queries.GetFilmDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class FilmController : EntityControllerBase
    {
        public FilmController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public async Task<IActionResult> Index(int id)
        {
            var film = await _mediator.Send(new GetFilmDetailsQuery { Id = id });

            return View(film);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var dto = await GetDto(new GetFilmDetailsQuery { Id = id });

            return View(dto);
        }

        protected override string GetEntityType()
        {
            return "Film";
        }
    }
}
