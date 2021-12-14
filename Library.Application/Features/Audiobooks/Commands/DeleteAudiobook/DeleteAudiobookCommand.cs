using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Audiobooks.Commands.DeleteAudiobook
{
    public class DeleteAudiobookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
