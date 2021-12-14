using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Films.Commands.DeleteFilm
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, int>
    {
        private readonly IFilmsRepository _filmsRepository;

        public DeleteFilmCommandHandler(IFilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        public async Task<int> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await _filmsRepository.GetByIdAsync(request.Id);

            if (film != null)
                await _filmsRepository.DeleteAsync(film);

            return film.DigitalEntityId;
        }
    }
}