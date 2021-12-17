using AutoMapper;
using Library.Application.Contracts.Repositories;

namespace Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList
{
    public abstract class HandlerBase
    {
        protected readonly IAudiobooksRepository _audiobooksRepository;
        protected readonly IBooksRepository _booksRepository;
        protected readonly IMagazinesRepository _magazinesRepository;
        protected readonly IFilmsRepository _filmsRepository;
        protected readonly IMapper _mapper;

        protected HandlerBase(IAudiobooksRepository audiobooksRepository,
            IBooksRepository booksRepository,
            IMagazinesRepository magazinesRepository,
            IFilmsRepository filmsRepository,
            IMapper mapper)
        {
            _audiobooksRepository = audiobooksRepository;
            _booksRepository = booksRepository;
            _magazinesRepository = magazinesRepository;
            _filmsRepository = filmsRepository;
            _mapper = mapper;
        }
    }
}