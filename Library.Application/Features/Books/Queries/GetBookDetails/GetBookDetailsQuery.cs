using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
