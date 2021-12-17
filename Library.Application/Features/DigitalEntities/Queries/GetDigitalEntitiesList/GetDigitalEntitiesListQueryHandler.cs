using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using Library.Application.ViewModels;
using Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList;

namespace Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList
{
    public class GetDigitalEntitiesListQueryHandler : HandlerBase, IRequestHandler<GetDigitalEntitiesListQuery, List<DigitalEntitiesListVM>>
    {
        public GetDigitalEntitiesListQueryHandler(IAudiobooksRepository audiobooksRepository, 
            IBooksRepository booksRepository, 
            IMagazinesRepository magazinesRepository, 
            IFilmsRepository filmsRepository, 
            IMapper mapper)
            : base(audiobooksRepository, booksRepository, magazinesRepository, filmsRepository, mapper)
        {
        }

        public async Task<List<DigitalEntitiesListVM>> Handle(GetDigitalEntitiesListQuery request, CancellationToken cancellationToken)
        {
            var allAudiobooks = _mapper.Map<List<DigitalEntitiesListVM>>(await _audiobooksRepository.GetAudiobooksWithTags());
            var allBooks = _mapper.Map<List<DigitalEntitiesListVM>>(await _booksRepository.GetBooksWithTags());
            var allMagazines = _mapper.Map<List<DigitalEntitiesListVM>>(await _magazinesRepository.GetMagazinesWithTags());
            var allFilms = _mapper.Map<List<DigitalEntitiesListVM>>(await _filmsRepository.GetFilmsWithTags());

            var allEntities = allAudiobooks.Concat(allBooks).Concat(allMagazines).Concat(allFilms).ToList();

            return allEntities;
        }
    }
}
