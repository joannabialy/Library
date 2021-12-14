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

namespace Library.Application.Features.Magazines.Commands.CreateMagazine
{
    public class CreateMagazineCommandHandler : IRequestHandler<CreateMagazineCommand, int>
    {
        private readonly IMagazinesRepository _magazinesRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public CreateMagazineCommandHandler(IMagazinesRepository magazinesRepository, ICompaniesRepository companiesRepository, ITagsRepository tagsRepository, IMapper mapper)
        {
            _magazinesRepository = magazinesRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMagazineCommand request, CancellationToken cancellationToken)
        {
            var magazine = _mapper.Map<Magazine>(request.MagazineDto);

            magazine.Company = await _companiesRepository.GetByName(request.MagazineDto.CompanyName) ?? new Company()
            {
                Name = request.MagazineDto.CompanyName
            };

            foreach (var tagName in request.MagazineDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                magazine.Tags.Add(tag);
            }

            using (var memoryStream = new MemoryStream())
            {
                await request.MagazineDto.ImageFormFile.CopyToAsync(memoryStream);

                magazine.Image = memoryStream.ToArray();
            }

            return (await _magazinesRepository.AddAsync(magazine)).DigitalEntityId;
        }
    }
}
