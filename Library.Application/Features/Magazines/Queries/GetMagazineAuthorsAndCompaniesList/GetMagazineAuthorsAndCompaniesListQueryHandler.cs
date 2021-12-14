using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Queries.GetMagazineAuthorsAndCompaniesList
{
    public class GetMagazineAuthorsAndCompaniesListQueryHandler : IRequestHandler<GetMagazineAuthorsAndCompaniesListQuery, PersonsAndCompaniesVM>
    {
        private readonly IMagazinesRepository _magazineRepository;

        public GetMagazineAuthorsAndCompaniesListQueryHandler(IMagazinesRepository magazineRepository)
        {
            _magazineRepository = magazineRepository;
        }

        public async Task<PersonsAndCompaniesVM> Handle(GetMagazineAuthorsAndCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var companies = (await _magazineRepository.GetMagazinesWithCompanies()).Select(x => x.Company).Distinct().ToList();

            return new PersonsAndCompaniesVM
            {
                Companies = companies
            };
        }
    }   
}