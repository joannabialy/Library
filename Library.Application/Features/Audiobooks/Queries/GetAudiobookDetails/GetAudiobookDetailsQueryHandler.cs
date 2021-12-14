using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Queries.GetAudiobookDetails
{
    public class GetAudiobookDetailsQueryHandler : IRequestHandler<GetAudiobookDetailsQuery, Audiobook>
    {
        private readonly IAudiobooksRepository _audiobookRepository;

        public GetAudiobookDetailsQueryHandler(IAudiobooksRepository audiobookRepository)
        {
            _audiobookRepository = audiobookRepository;
        }

        public async Task<Audiobook> Handle(GetAudiobookDetailsQuery request, CancellationToken cancellationToken)
        {
            var audiobook = await _audiobookRepository.GetAudiobook(request.Id);

            return audiobook;
        }
    }   
}