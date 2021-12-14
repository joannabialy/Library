﻿using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Films.Commands.CreateFilm
{
    public class CreateFilmCommand : IRequest<int>
    {
        public FilmDto FilmDto { get; set; }
    }
}
