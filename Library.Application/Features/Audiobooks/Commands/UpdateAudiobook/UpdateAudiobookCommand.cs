using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.Audiobooks.Commands.UpdateAudiobook
{
    public class UpdateAudiobookCommand : IRequest<int>
    {
        public AudiobookDto AudiobookDto { get; set; }

    }
}
