using AutoMapper;
using Library.Application.Features.Magazines.Queries.GetMagazineDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class MagazineController : EntityControllerBase
    {
        public MagazineController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public async Task<IActionResult> Index(int id)
        {
            var magazine = await _mediator.Send(new GetMagazineDetailsQuery { Id = id });

            return View(magazine);
        }


        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var dto = await GetDto(new GetMagazineDetailsQuery { Id = id });

            return View(dto);
        }

        protected override string GetEntityType()
        {
            return "Magazine";
        }
    }
}
