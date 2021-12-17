using AutoMapper;
using Library.Application.Features.Audiobooks.Queries.GetAudiobookDetails;
using Library.Application.Features.DigitalEntities.Commands.CreateDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.DeleteDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.UpdateDigitalEntity;
using Library.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class AudiobookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AudiobookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id)
        {
            var query = new GetAudiobookDetailsQuery
            {
                Id = id
            };

            var audiobook = await _mediator.Send(query);

            return View(audiobook);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var query = new GetAudiobookDetailsQuery
            {
                Id = id
            };

            var audiobook = await _mediator.Send(query);
            var audiobookDto = _mapper.Map<DigitalEntityDto>(audiobook);

            audiobookDto.Tags = string.Join(",", audiobook.Tags.Select(x => x.Name));

            return View(audiobookDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(DigitalEntityDto audiobookDto)
        {
            if (ModelState.IsValid)
            {
                if (audiobookDto.DigitalEntityId == 0)
                {
                    var command = new CreateDigitalEntityCommand
                    {
                        DigitalEntityDto = audiobookDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateDigitalEntityCommand
                    {
                        DigitalEntityDto = audiobookDto
                    };

                    await _mediator.Send(command);
                }
                
                return RedirectToAction("Index", "DigitalEntity");
            }
            else
            {
                return View(audiobookDto);
            }
        }


        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {
            return View("Edit", new DigitalEntityDto() {Type = "Audiobook"});
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
