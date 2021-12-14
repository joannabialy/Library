using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Audiobooks.Queries.GetAudiobookAuthorsAndCompaniesList
{
    public class GetAudiobookAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
    }
}
