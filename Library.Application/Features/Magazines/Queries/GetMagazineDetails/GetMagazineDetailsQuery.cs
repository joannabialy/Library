using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Queries.GetMagazineDetails
{
    public class GetMagazineDetailsQuery : IRequest<Magazine>
    {
        public int Id { get; set; }
    }
}
