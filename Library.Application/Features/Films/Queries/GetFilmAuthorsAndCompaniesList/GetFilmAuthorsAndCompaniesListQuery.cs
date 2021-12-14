using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Films.Queries.GetFilmAuthorsAndCompaniesList
{
    public class GetFilmAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
    }
}
