using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Commands.CreateAudiobook
{
    public class CreateAudiobookCommand : IRequest<int>
    {
        public AudiobookDto AudiobookDto { get; set; }

    }
}
