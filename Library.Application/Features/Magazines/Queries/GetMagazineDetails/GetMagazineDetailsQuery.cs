using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Magazines.Queries.GetMagazineDetails
{
    public class GetMagazineDetailsQuery : IRequest<Magazine>
    {
        public int Id { get; set; }
    }
}
