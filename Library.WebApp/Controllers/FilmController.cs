using Library.Application.Features.DigitalEntities.Commands.CreateDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.DeleteDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.UpdateDigitalEntity;
using Library.Application.Features.Films.Queries.GetFilmDetails;
using Library.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class FilmController : Controller
    {
        private readonly IMediator _mediator;

        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int id)
        {
            var query = new GetFilmDetailsQuery
            {
                Id = id
            };

            var film = await _mediator.Send(query);

            return View(film);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var query = new GetFilmDetailsQuery
            {
                Id = id
            };

            var film = await _mediator.Send(query);

            return View(film);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(DigitalEntityDto filmDto)
        {
            if (ModelState.IsValid)
            {
                if (filmDto.DigitalEntityId == 0)
                {
                    var command = new CreateDigitalEntityCommand
                    {
                        DigitalEntityDto = filmDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateDigitalEntityCommand
                    {
                        DigitalEntityDto = filmDto
                    };

                    await _mediator.Send(command);
                }

                return RedirectToAction("Index", "DigitalEntity");
            }
            else
            {
                return View(filmDto);
            }
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {
            return View("Edit", new FilmDto());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDigitalEntityCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "DigitalEntity");
        }
    }
}
