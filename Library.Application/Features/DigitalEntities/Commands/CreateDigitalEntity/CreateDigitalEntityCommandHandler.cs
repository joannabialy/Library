using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Commands.CreateDigitalEntity
{
    public class CreateDigitalEntityCommandHandler : UpdateCreateHandlerBase, IRequestHandler<CreateDigitalEntityCommand, int>
    {
        public CreateDigitalEntityCommandHandler(IPersonsRepository personsRepository,
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

        public async Task<int> Handle(CreateDigitalEntityCommand request, CancellationToken cancellationToken)
        {
            switch (request.DigitalEntityDto.Type)
            {
                case "Audiobook":
                    var audiobook = await GetEntity<Audiobook>(request.DigitalEntityDto);
                    return (await _audiobooksRepository.AddAsync(audiobook)).DigitalEntityId;

                case "Book":
                    var book = await GetEntity<Book>(request.DigitalEntityDto);
                    return (await _booksRepository.AddAsync(book)).DigitalEntityId;

                case "Film":
                    var film = await GetEntity<Film>(request.DigitalEntityDto);
                    return (await _filmsRepository.AddAsync(film)).DigitalEntityId;

                case "Magazine":
                    var magazine = await GetEntity<Magazine>(request.DigitalEntityDto);
                    return (await _magazinesRepository.AddAsync(magazine)).DigitalEntityId;
            }

            throw new Exception("Unsupported type");
        }
    }
}
