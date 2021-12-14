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

namespace Library.Application.Features.Magazines.Commands.UpdateMagazine
{
    public class UpdateMagazineCommandHandler : IRequestHandler<UpdateMagazineCommand, int>
    {
        private readonly IMagazinesRepository _magazinesRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public UpdateMagazineCommandHandler(IMagazinesRepository magazinesRepository, ICompaniesRepository companiesRepository, ITagsRepository tagsRepository, IMapper mapper)
        {
            _magazinesRepository = magazinesRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateMagazineCommand request, CancellationToken cancellationToken)
        {
            var magazine = await _magazinesRepository.GetMagazine(request.MagazineDto.DigitalEntityId);

            magazine.Company = await _companiesRepository.GetByName(request.MagazineDto.CompanyName) ?? new Company()
            {
                Name = request.MagazineDto.CompanyName
            };

            magazine.Tags.Clear();
            foreach (var tagName in request.MagazineDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                magazine.Tags.Add(tag);
            }

            if (request.MagazineDto.ImageFormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.MagazineDto.ImageFormFile.CopyToAsync(memoryStream);

                    magazine.Image = memoryStream.ToArray();
                }
            }

            return (await _magazinesRepository.AddAsync(magazine)).DigitalEntityId;
        }
    }
}
