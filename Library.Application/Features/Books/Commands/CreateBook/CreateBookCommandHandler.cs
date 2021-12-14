using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBooksRepository booksRepository, IPersonsRepository personsRepository, ICompaniesRepository companiesRepository, ITagsRepository tagsRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.BookDto);

            book.Author = await _personsRepository.GetByName(request.BookDto.AuthorFirstName, request.BookDto.AuthorLastName) ?? new Person()
            {
                FirstName = request.BookDto.AuthorFirstName,
                LastName = request.BookDto.AuthorLastName
            };

            book.Company = await _companiesRepository.GetByName(request.BookDto.CompanyName) ?? new Company()
            {
                Name = request.BookDto.CompanyName
            };

            foreach (var tagName in request.BookDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                book.Tags.Add(tag);
            }

            using (var memoryStream = new MemoryStream())
            {
                await request.BookDto.ImageFormFile.CopyToAsync(memoryStream);

                book.Image = memoryStream.ToArray();
            }

            return (await _booksRepository.AddAsync(book)).DigitalEntityId;
        }
    }
}
