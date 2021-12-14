using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Queries.GetAudiobookAuthorsAndCompaniesList
{
    public class GetAudiobookAuthorsAndCompaniesListyHandler : IRequestHandler<GetAudiobookAuthorsAndCompaniesListQuery, PersonsAndCompaniesVM>
    {
        private readonly IAudiobooksRepository _audiobookRepository;

        public GetAudiobookAuthorsAndCompaniesListyHandler(IAudiobooksRepository audiobookRepository)
        {
            _audiobookRepository = audiobookRepository;
        }

        public async Task<PersonsAndCompaniesVM> Handle(GetAudiobookAuthorsAndCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var authors = (await _audiobookRepository.GetAudiobooksWithAuthorsAndCompanies()).Select(x => x.Author).Distinct().ToList();
            var companies = (await _audiobookRepository.GetAudiobooksWithAuthorsAndCompanies()).Select(x => x.Company).Distinct().ToList();

            return new PersonsAndCompaniesVM
            { 
                Persons = authors,
                Companies = companies
            };
        }
    }   
}