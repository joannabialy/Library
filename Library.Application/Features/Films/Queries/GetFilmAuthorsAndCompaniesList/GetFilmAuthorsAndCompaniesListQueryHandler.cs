using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Films.Queries.GetFilmAuthorsAndCompaniesList
{
    public class GetFilmAuthorsAndCompaniesListQueryHandler : IRequestHandler<GetFilmAuthorsAndCompaniesListQuery, PersonsAndCompaniesVM>
    {
        private readonly IFilmsRepository _filmRepository;

        public GetFilmAuthorsAndCompaniesListQueryHandler(IFilmsRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<PersonsAndCompaniesVM> Handle(GetFilmAuthorsAndCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var directors = (await _filmRepository.GetFilmsWithDirectorsAndCompanies()).Select(x => x.Director).Distinct().ToList();
            var companies = (await _filmRepository.GetFilmsWithDirectorsAndCompanies()).Select(x => x.Company).Distinct().ToList();

            return new PersonsAndCompaniesVM
            { 
                Persons = directors,
                Companies = companies
            };
        }
    }   
}