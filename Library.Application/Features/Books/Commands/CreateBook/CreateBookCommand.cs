using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public BookDto BookDto { get; set; }

    }
}
