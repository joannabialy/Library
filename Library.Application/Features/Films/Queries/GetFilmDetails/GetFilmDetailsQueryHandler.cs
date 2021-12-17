using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Films.Queries.GetFilmDetails
{
    public class GetFilmDetailsQueryHandler : IRequestHandler<GetFilmDetailsQuery, Film>
    {
        private readonly IFilmsRepository _filmRepository;

        public GetFilmDetailsQueryHandler(IFilmsRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<Film> Handle(GetFilmDetailsQuery request, CancellationToken cancellationToken)
        {
            var film = await _filmRepository.GetFilm(request.Id);

            return film;
        }
    }
}