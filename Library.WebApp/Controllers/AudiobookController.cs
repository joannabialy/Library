using AutoMapper;
using Library.Application.Features.Audiobooks.Commands.CreateAudiobook;
using Library.Application.Features.Audiobooks.Commands.DeleteAudiobook;
using Library.Application.Features.Audiobooks.Commands.UpdateAudiobook;
using Library.Application.Features.Audiobooks.Queries.GetAudiobookDetails;
using Library.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var audiobookDto = _mapper.Map<AudiobookDto>(audiobook);

            audiobookDto.Tags = string.Join(",", audiobook.Tags.Select(x => x.Name));

            return View(audiobookDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(AudiobookDto audiobookDto)
        {
            if (ModelState.IsValid)
            {
                if (audiobookDto.DigitalEntityId == 0)
                {
                    var command = new CreateAudiobookCommand
                    {
                        AudiobookDto = audiobookDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateAudiobookCommand
                    {
                        AudiobookDto = audiobookDto
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
            return View("Edit", new AudiobookDto());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAudiobookCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "DigitalEntity");
        }
    }
}
