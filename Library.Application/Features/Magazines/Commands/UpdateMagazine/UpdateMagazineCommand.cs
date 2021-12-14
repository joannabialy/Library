using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Commands.UpdateMagazine
{
    public class UpdateMagazineCommand : IRequest<int>
    {
        public MagazineDto MagazineDto { get; set; }
    }
}
