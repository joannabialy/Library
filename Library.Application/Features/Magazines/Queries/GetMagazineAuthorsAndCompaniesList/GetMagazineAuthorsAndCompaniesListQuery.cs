using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Magazines.Queries.GetMagazineAuthorsAndCompaniesList
{
    public class GetMagazineAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
    }
}
