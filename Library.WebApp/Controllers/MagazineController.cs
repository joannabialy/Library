using Library.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Library.Application.Features.Magazines.Queries.GetMagazineDetails;
using Library.Application.Features.Magazines.Commands.CreateMagazine;
using Library.Application.Features.Magazines.Commands.UpdateMagazine;
using Library.Application.Features.Magazines.Commands.DeleteMagazine;

namespace Library.WebApp.Controllers
{
    public class MagazineController : Controller
    {
        private readonly IMediator _mediator;

        public MagazineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int id)
        {
            var query = new GetMagazineDetailsQuery
            {
                Id = id
            };

            var magazine = await _mediator.Send(query);

            return View(magazine);
        }


        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var query = new GetMagazineDetailsQuery
            {
                Id = id
            };

            var magazine = await _mediator.Send(query);

            return View(magazine);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(MagazineDto magazineDto)
        {
            if (ModelState.IsValid)
            {
                if (magazineDto.DigitalEntityId == 0)
                {
                    var command = new CreateMagazineCommand
                    {
                        MagazineDto = magazineDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateMagazineCommand
                    {
                        MagazineDto = magazineDto
                    };

                    await _mediator.Send(command);
                }

                return RedirectToAction("Index", "DigitalEntity");
            }
            else
            {
                return View(magazineDto);
            }
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {
            return View("Edit", new MagazineDto());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMagazineCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "DigitalEntity");
        }
    }
}
