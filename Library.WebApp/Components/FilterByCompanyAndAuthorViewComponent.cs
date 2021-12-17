using Library.Application.Features.DigitalEntities.Queries.GetAuthorsAndCompaniesList;
using Library.Application.ViewModels;
using Library.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Components
{
    public class FilterByCompanyAndAuthorViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public FilterByCompanyAndAuthorViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var selectedType = ViewBag.SelectedType;

            var personsAndCompanies = await _mediator.Send(new GetAuthorsAndCompaniesListQuery() { Type = selectedType });

            return View(GetFilterVM(personsAndCompanies, selectedType));
        }

        private FilterVM GetFilterVM(PersonsAndCompaniesVM personsAndCompanies, string type)
        {
            var types = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Audiobook", Value = "Audiobook" },
                new SelectListItem { Text = "Książka", Value = "Book" },
                new SelectListItem { Text = "Film", Value = "Film" },
                new SelectListItem { Text = "Magazyn", Value = "Magazine" }
            };

            return new FilterVM
            {
                Persons = personsAndCompanies.Persons.Select(x => new SelectListItem { Text = x.ToString(), Value = Convert.ToString(x.Id) }).ToList(),
                Companies = personsAndCompanies.Companies.Select(x => new SelectListItem { Text = x.ToString(), Value = Convert.ToString(x.Id) }).ToList(),
                Types = types,
                PreviousType = type
            };
        }
    }
}
