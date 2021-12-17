using AutoMapper;
using Library.Application.Features.Audiobooks.Queries.GetAudiobookDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class AudiobookController : EntityControllerBase
    {
        public AudiobookController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public async Task<IActionResult> Index(int id)
        {
            var audiobook = await _mediator.Send(new GetAudiobookDetailsQuery { Id = id });

            return View(audiobook);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var dto = await GetDto(new GetAudiobookDetailsQuery { Id = id });

            return View(dto);
        }

        protected override string GetEntityType()
        {
            return "Audiobook";
        }
    }
}
