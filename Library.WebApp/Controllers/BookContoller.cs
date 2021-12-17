using AutoMapper;
using Library.Application.Features.Books.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class BookController : EntityControllerBase
    {
        public BookController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public async Task<IActionResult> Index(int id)
        {
            var book = await _mediator.Send(new GetBookDetailsQuery { Id = id });

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Edit(int id)
        {
            var dto = await GetDto(new GetBookDetailsQuery { Id = id });

            return View(dto);
        }

        protected override string GetEntityType()
        {
            return "Book";
        }
    }
}
