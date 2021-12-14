using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookAuthorsAndCompaniesList
{
    public class GetBookAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
    }
}
