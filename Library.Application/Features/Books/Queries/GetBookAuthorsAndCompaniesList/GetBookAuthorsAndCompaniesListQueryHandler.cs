using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.GetBookAuthorsAndCompaniesList
{
    public class GetBookAuthorsAndCompaniesListQueryHandler : IRequestHandler<GetBookAuthorsAndCompaniesListQuery, PersonsAndCompaniesVM>
    {
        private readonly IBooksRepository _bookRepository;

        public GetBookAuthorsAndCompaniesListQueryHandler(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PersonsAndCompaniesVM> Handle(GetBookAuthorsAndCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var authors = (await _bookRepository.GetBooksWithAuthorsAndCompanies()).Select(x => x.Author).Distinct().Distinct().ToList();
            var companies = (await _bookRepository.GetBooksWithAuthorsAndCompanies()).Select(x => x.Company).Distinct().Distinct().ToList();

            return new PersonsAndCompaniesVM
            { 
                Persons = authors,
                Companies = companies
            };
        }
    }   
}