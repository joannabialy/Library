using AutoMapper;
using Library.Application.Features.Books.Queries.GetBookDetails;
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
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id)
        {
            var query = new GetBookDetailsQuery
            {
                Id = id
            };

            var book = await _mediator.Send(query);

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var query = new GetBookDetailsQuery
            {
                Id = id
            };

            var book = await _mediator.Send(query);
            var bookDto = _mapper.Map<DigitalEntityDto>(book);
            bookDto.Tags = string.Join(",", book.Tags.Select(x => x.Name));

            return View(bookDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(DigitalEntityDto bookDto)
        {
            if (ModelState.IsValid)
            {
                if (bookDto.DigitalEntityId == 0)
                {
                    var command = new CreateDigitalEntityCommand
                    {
                        DigitalEntityDto = bookDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateDigitalEntityCommand
                    {
                        DigitalEntityDto = bookDto
                    };

                    await _mediator.Send(command);
                }

                return RedirectToAction("Index", "DigitalEntity");
            }
            else
            {
                return View(bookDto);
            }
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {
            return View("Edit", new BookDto());
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
