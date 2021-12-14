using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Films.Commands.UpdateFilm
{
    class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, int>
    {
        private readonly IFilmsRepository _filmsRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmsRepository filmsRepository, IPersonsRepository personsRepository, ICompaniesRepository companiesRepository, ITagsRepository tagsRepository, IMapper mapper)
        {
            _filmsRepository = filmsRepository;
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await _filmsRepository.GetFilm(request.FilmDto.DigitalEntityId);

            film.Title = request.FilmDto.Title;
            film.Length = request.FilmDto.Length;
            film.PremiereDate = request.FilmDto.PremiereDate;

            film.Director = await _personsRepository.GetByName(request.FilmDto.DirectorFirstName, request.FilmDto.DirectorLastName) ?? new Person()
            {
                FirstName = request.FilmDto.DirectorFirstName,
                LastName = request.FilmDto.DirectorLastName
            };

            film.Company = await _companiesRepository.GetByName(request.FilmDto.CompanyName) ?? new Company()
            {
                Name = request.FilmDto.CompanyName
            };

            film.Tags.Clear();
            foreach (var tagName in request.FilmDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                film.Tags.Add(tag);
            }

            if (request.FilmDto.ImageFormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.FilmDto.ImageFormFile.CopyToAsync(memoryStream);

                    film.Image = memoryStream.ToArray();
                }
            }

            return (await _filmsRepository.AddAsync(film)).DigitalEntityId;
        }
    }
}
