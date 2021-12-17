using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList
{
    public class GetAuthorsAndCompaniesListQueryHandler : HandlerBase, IRequestHandler<GetAuthorsAndCompaniesListQuery, PersonsAndCompaniesVM>
    {
        public GetAuthorsAndCompaniesListQueryHandler(IAudiobooksRepository audiobooksRepository,
            IBooksRepository booksRepository,
            IMagazinesRepository magazinesRepository,
            IFilmsRepository filmsRepository,
            IMapper mapper)
            : base(audiobooksRepository, booksRepository, magazinesRepository, filmsRepository, mapper)
        {
        }

        public async Task<PersonsAndCompaniesVM> Handle(GetAuthorsAndCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var persons = new List<Person>();
            var companies = new List<Company>();

            switch (request.Type)
            {
                case "Audiobook":
                    persons = await _audiobooksRepository.GetAuthors();
                    companies = await _audiobooksRepository.GetCompanies();
                    break;

                case "Book":
                    persons = await _booksRepository.GetAuthors();
                    companies = await _booksRepository.GetCompanies();
                    break;

                case "Film":
                    persons = await _filmsRepository.GetDirectors();
                    companies = await _filmsRepository.GetCompanies();
                    break;

                case "Magazine":
                    companies = await _filmsRepository.GetCompanies();
                    break;
            }

            return new PersonsAndCompaniesVM
            {
                Persons = persons,
                Companies = companies
            };
        }
    }
}
