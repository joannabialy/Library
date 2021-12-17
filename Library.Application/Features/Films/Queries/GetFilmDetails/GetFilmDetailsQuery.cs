using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Films.Queries.GetFilmDetails
{
    public class GetFilmDetailsQuery : IRequest<Film>
    {
        public int Id { get; set; }
    }
}
