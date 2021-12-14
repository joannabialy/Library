using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Audiobooks.Queries.GetAudiobookDetails
{
    public class GetAudiobookDetailsQuery : IRequest<Audiobook>
    {
        public int Id { get; set; }
    }
}
