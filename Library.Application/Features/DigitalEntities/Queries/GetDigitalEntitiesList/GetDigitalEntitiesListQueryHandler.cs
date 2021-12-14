using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Common;
using AutoMapper;
using System.Threading;
using Library.Domain.Entities;

namespace Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList
{
    public class GetDigitalEntitiesListQueryHandler : IRequestHandler<GetDigitalEntitiesListQuery, List<DigitalEntitiesListVM>>
    {
        private readonly IAudiobooksRepository _audiobookRepository;
        private readonly IBooksRepository _bookRepository;
        private readonly IMagazinesRepository _magazineRepository;
        private readonly IFilmsRepository _filmRepository;
        private readonly IMapper _mapper;

        public GetDigitalEntitiesListQueryHandler(IAudiobooksRepository audiobookRepository, IBooksRepository bookRepository, IMagazinesRepository magazineRepository, IFilmsRepository filmRepository, IMapper mapper)
        {
            _audiobookRepository = audiobookRepository;
            _bookRepository = bookRepository;
            _magazineRepository = magazineRepository;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<List<DigitalEntitiesListVM>> Handle(GetDigitalEntitiesListQuery request, CancellationToken cancellationToken)
        {
            var allAudiobooks = _mapper.Map<List<DigitalEntitiesListVM>>(await _audiobookRepository.GetAudiobooksWithTags());
            var allBooks = _mapper.Map<List<DigitalEntitiesListVM>>(await _bookRepository.GetBooksWithTags());
            var allMagazines = _mapper.Map<List<DigitalEntitiesListVM>>(await _magazineRepository.GetMagazinesWithTags());
            var allFilms = _mapper.Map<List<DigitalEntitiesListVM>>(await _filmRepository.GetFilmsWithTags());

            var allEntities = allAudiobooks.Concat(allBooks).Concat(allMagazines).Concat(allFilms).ToList();

            return allEntities;
        }
    }
}
