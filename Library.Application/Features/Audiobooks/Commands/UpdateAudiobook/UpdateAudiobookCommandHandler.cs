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

namespace Library.Application.Features.Audiobooks.Commands.UpdateAudiobook
{
    public class UpdateAudiobookCommandHandler : IRequestHandler<UpdateAudiobookCommand, int>
    {
        private readonly IAudiobooksRepository _audiobooksRepository;
        private readonly IPersonsRepository _personsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public UpdateAudiobookCommandHandler(IAudiobooksRepository audiobooksRepository, IPersonsRepository personsRepository, ICompaniesRepository companiesRepository, IMapper mapper, ITagsRepository tagsRepository)
        {
            _audiobooksRepository = audiobooksRepository;
            _personsRepository = personsRepository;
            _companiesRepository = companiesRepository;
            _tagsRepository = tagsRepository;

            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateAudiobookCommand request, CancellationToken cancellationToken)
        {
            var audiobook = await _audiobooksRepository.GetAudiobook(request.AudiobookDto.DigitalEntityId);

            audiobook.Title = request.AudiobookDto.Title;
            audiobook.Length = request.AudiobookDto.Length;
            audiobook.PublicationDate = request.AudiobookDto.PublicationDate;

            audiobook.Author = await _personsRepository.GetByName(request.AudiobookDto.AuthorFirstName, request.AudiobookDto.AuthorLastName) ?? new Person()
            {
                FirstName = request.AudiobookDto.AuthorFirstName,
                LastName = request.AudiobookDto.AuthorLastName
            };

            audiobook.Company = await _companiesRepository.GetByName(request.AudiobookDto.CompanyName) ?? new Company()
            {
                Name = request.AudiobookDto.CompanyName
            };

            if (request.AudiobookDto.ImageFormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.AudiobookDto.ImageFormFile.CopyToAsync(memoryStream);

                    audiobook.Image = memoryStream.ToArray();
                }
            }

            audiobook.Tags.Clear();
            foreach (var tagName in request.AudiobookDto.Tags.Split(","))
            {
                var tag = await _tagsRepository.GetByName(tagName) ?? new Tag { Name = tagName };
                audiobook.Tags.Add(tag);
            }

            await _audiobooksRepository.UpdateAsync(audiobook);

            return audiobook.DigitalEntityId;
        }
    }
}
