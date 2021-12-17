using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
