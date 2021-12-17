using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Commands.UpdateDigitalEntity
{
    class UpdateDigitalEntityCommandHandler : UpdateCreateHandlerBase, IRequestHandler<UpdateDigitalEntityCommand, int>
    {

        protected UpdateDigitalEntityCommandHandler(IPersonsRepository personsRepository,
            ICompaniesRepository companiesRepository,
            ITagsRepository tagsRepository,
            IAsyncDomainRepository<Audiobook> audiobooksRepository,
            IAsyncDomainRepository<Book> booksRepository,
            IAsyncDomainRepository<Film> filmsRepository,
            IAsyncDomainRepository<Magazine> magazinesRepository,
            IMapper mapper)
            : base(personsRepository, companiesRepository, tagsRepository, audiobooksRepository, booksRepository, filmsRepository, magazinesRepository, mapper)
        {
        }

        public async Task<int> Handle(UpdateDigitalEntityCommand request, CancellationToken cancellationToken)
        {
            switch (request.DigitalEntityDto.Type)
            {
                case "Audiobook":
                    var audiobook = await GetEntity<Audiobook>(request.DigitalEntityDto);
                    await _audiobooksRepository.UpdateAsync(audiobook);
                    return audiobook.DigitalEntityId;

                case "Book":
                    var book = await GetEntity<Book>(request.DigitalEntityDto);
                    await _booksRepository.UpdateAsync(book);
                    return book.DigitalEntityId;

                case "Film":
                    var film = await GetEntity<Film>(request.DigitalEntityDto);
                    await _filmsRepository.UpdateAsync(film);
                    return film.DigitalEntityId;

                case "Magazine":
                    var magazine = await GetEntity<Magazine>(request.DigitalEntityDto);
                    await _magazinesRepository.UpdateAsync(magazine);
                    return magazine.DigitalEntityId;
            }

            throw new Exception("Unsupported type");
        }
    }
}
