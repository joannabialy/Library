using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Application.ViewModels;
using Library.Domain.Common;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Commands
{
    public abstract class UpdateCreateHandlerBase
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;

        protected readonly IAsyncDomainRepository<Audiobook> _audiobooksRepository;
        protected readonly IAsyncDomainRepository<Book> _booksRepository;
        protected readonly IAsyncDomainRepository<Film> _filmsRepository;
        protected readonly IAsyncDomainRepository<Magazine> _magazinesRepository;

        private readonly IMapper _mapper;

        protected UpdateCreateHandlerBase(IPersonsRepository personsRepository, 
            ICompaniesRepository companiesRepository, 
            ITagsRepository tagsRepository, 
            IAsyncDomainRepository<Audiobook> audiobooksRepository, 
            IAsyncDomainRepository<Book> booksRepository, 
            IAsyncDomainRepository<Film> filmsRepository, 
            IAsyncDomainRepository<Magazine> magazinesRepository, 
            IMapper mapper)
        {
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;
            _audiobooksRepository = audiobooksRepository;
            _booksRepository = booksRepository;
            _filmsRepository = filmsRepository;
            _magazinesRepository = magazinesRepository;
            _mapper = mapper;
        }

        protected async Task<T> GetEntity<T>(DigitalEntityDto dto) where T : DigitalEntity
        {
            var digitalEntity = _mapper.Map<T>(dto);

            if (digitalEntity is Audiobook audiobook)
            {
                audiobook.Author = await UpdatePerson(dto.PersonFirstName, dto.PersonLastName);
            }
            else if (digitalEntity is Book book)
            {
                book.Author = await UpdatePerson(dto.PersonFirstName, dto.PersonLastName);
            }
            else if (digitalEntity is Film film)
            {
                film.Director = await UpdatePerson(dto.PersonFirstName, dto.PersonLastName);
            }

            await UpdateCompany(dto.CompanyName, digitalEntity);

            await UpdateTags(dto.Tags, digitalEntity);

            await UpdateImage(dto.ImageFormFile, digitalEntity);

            return digitalEntity;
        }

        private async Task<Person> UpdatePerson(string firstName, string lastName)
        {
            return await _personsRepository.GetByName(firstName, lastName) ?? new Person()
            {
                FirstName = firstName,
                LastName = lastName
            };
        }

        private async Task UpdateCompany<T>(string name, T entity) where T : DigitalEntity
        {
            entity.Company =  await _companiesRepository.GetByName(name) ?? new Company()
            {
                Name = name
            };
        }

        private async Task UpdateTags<T>(string tags, T entity) where T : DigitalEntity
        {
            foreach (var tagName in tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                entity.Tags.Add(tag);
            }
        }

        private async Task UpdateImage<T>(IFormFile formFile, T entity) where T : DigitalEntity
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                entity.Image = memoryStream.ToArray();
            }
        }
    }
}
