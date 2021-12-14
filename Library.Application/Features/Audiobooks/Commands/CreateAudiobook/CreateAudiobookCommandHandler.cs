using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Commands.CreateAudiobook
{
    public class CreateAudiobookCommandHandler : IRequestHandler<CreateAudiobookCommand, int>
    {
        private readonly IAudiobooksRepository _audiobooksRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public CreateAudiobookCommandHandler(IAudiobooksRepository audiobooksRepository, IPersonsRepository personsRepository, ICompaniesRepository companiesRepository, IMapper mapper, ITagsRepository tagsRepository)
        {
            _audiobooksRepository = audiobooksRepository;
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;

            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAudiobookCommand request, CancellationToken cancellationToken)
        {
            var audiobook = _mapper.Map<Audiobook>(request.AudiobookDto);

            audiobook.Author = await _personsRepository.GetByName(request.AudiobookDto.AuthorFirstName, request.AudiobookDto.AuthorLastName) ?? new Person()
            {
                FirstName = request.AudiobookDto.AuthorFirstName,
                LastName = request.AudiobookDto.AuthorLastName
            };

            audiobook.Company = await _companiesRepository.GetByName(request.AudiobookDto.CompanyName) ?? new Company()
            {
                Name = request.AudiobookDto.CompanyName
            };

            foreach (var tagName in request.AudiobookDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                audiobook.Tags.Add(tag);
            }

            if (request.AudiobookDto.ImageFormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.AudiobookDto.ImageFormFile.CopyToAsync(memoryStream);

                    audiobook.Image = memoryStream.ToArray();
                }
            }
            else
            {
                if (request.AudiobookDto.DigitalEntityId == 0)
                {
                    audiobook.Image = new byte[0];
                }
            }

            if (request.AudiobookDto.DigitalEntityId == 0)
            {
                audiobook = await _audiobooksRepository.AddAsync(audiobook);
            }
            else
            {
                await _audiobooksRepository.UpdateAsync(audiobook);
            }

            return audiobook.DigitalEntityId;
        }
    }
}
