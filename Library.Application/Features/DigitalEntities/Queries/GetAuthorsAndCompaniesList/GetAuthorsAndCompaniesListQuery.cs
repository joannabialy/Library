using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList
{
    public class GetAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
        public string Type { get; set; }
    }
}
