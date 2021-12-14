using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Commands.DeleteMagazine
{
    public class DeleteMagazineCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
