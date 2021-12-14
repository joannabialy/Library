using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBooksRepository _booksRepository;

        public DeleteBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetByIdAsync(request.Id);

            if (book != null)
                await _booksRepository.DeleteAsync(book);

            return book.DigitalEntityId;
        }
    }
}
