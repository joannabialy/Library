using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.DeleteBook;
using Library.Application.Features.Books.Commands.UpdateBook;
using Library.Application.Features.Books.Queries.GetBookDetails;
using Library.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
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

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                if (bookDto.DigitalEntityId == 0)
                {
                    var command = new CreateBookCommand
                    {
                        BookDto = bookDto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateBookCommand
                    {
                        BookDto = bookDto
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
            var command = new DeleteBookCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "DigitalEntity");
        }
    }
}
