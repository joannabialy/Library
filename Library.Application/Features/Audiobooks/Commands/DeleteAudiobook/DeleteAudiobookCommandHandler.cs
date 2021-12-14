using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Commands.DeleteAudiobook
{
    public class DeleteAudiobookCommandHandler : IRequestHandler<DeleteAudiobookCommand, int>
    {
        private readonly IAudiobooksRepository _audiobooksRepository;

        public DeleteAudiobookCommandHandler(IAudiobooksRepository audiobooksRepository)
        {
            _audiobooksRepository = audiobooksRepository;
        }

        public async Task<int> Handle(DeleteAudiobookCommand request, CancellationToken cancellationToken)
        {
            var audiobook = await _audiobooksRepository.GetByIdAsync(request.Id);

            if (audiobook != null)
                await _audiobooksRepository.DeleteAsync(audiobook);

            return audiobook.DigitalEntityId;
        }
    }
}
