using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.GetBookDetails
{
    public class GetMagazineDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, Book>
    {
        private readonly IBooksRepository _bookRepository;

        public GetMagazineDetailsQueryHandler(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBook(request.Id);

            return book;
        }
    }
}