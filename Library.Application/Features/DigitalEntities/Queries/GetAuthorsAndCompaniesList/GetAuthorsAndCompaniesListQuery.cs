﻿using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList
{
    public class GetAuthorsAndCompaniesListQuery : IRequest<PersonsAndCompaniesVM>
    {
        public string Type { get; set; }
    }
}