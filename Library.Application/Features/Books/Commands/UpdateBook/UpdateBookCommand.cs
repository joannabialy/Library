using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
    {
        public BookDto BookDto { get; set; }
    }
}
