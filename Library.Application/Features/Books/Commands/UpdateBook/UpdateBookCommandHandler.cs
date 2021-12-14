using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBooksRepository booksRepository, IPersonsRepository personsRepository, ICompaniesRepository companiesRepository, IMapper mapper, ITagsRepository tagsRepository)
        {
            _booksRepository = booksRepository;
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;

            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBook(request.BookDto.DigitalEntityId);

            book.Title = request.BookDto.Title;
            book.Length = request.BookDto.Length;
            book.PublicationDate = request.BookDto.PublicationDate;

            book.Author = await _personsRepository.GetByName(request.BookDto.AuthorFirstName, request.BookDto.AuthorLastName) ?? new Person()
            {
                FirstName = request.BookDto.AuthorFirstName,
                LastName = request.BookDto.AuthorLastName
            };

            book.Company = await _companiesRepository.GetByName(request.BookDto.CompanyName) ?? new Company()
            {
                Name = request.BookDto.CompanyName
            };

            if (request.BookDto.ImageFormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.BookDto.ImageFormFile.CopyToAsync(memoryStream);

                    book.Image = memoryStream.ToArray();
                }
            }

            book.Tags.Clear();
            foreach (var tagName in request.BookDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                book.Tags.Add(tag);
            }

            await _booksRepository.UpdateAsync(book);

            return book.DigitalEntityId;
        }
    }
}
