using Library.Application.Features.Audiobooks.Queries.GetAudiobookAuthorsAndCompaniesList;
using Library.Application.Features.Books.Queries.GetBookAuthorsAndCompaniesList;
using Library.Application.Features.Films.Queries.GetFilmAuthorsAndCompaniesList;
using Library.Application.Features.Magazines.Queries.GetMagazineAuthorsAndCompaniesList;
using Library.Application.ViewModels;
using Library.WebApp.Components.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

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
            
            var personsAndCompanies = new PersonsAndCompaniesVM();

            switch (ViewBag.SelectedType)
            {
                case "Book":
                    personsAndCompanies = await _mediator.Send(new GetBookAuthorsAndCompaniesListQuery());
                    ViewBag.SelectedTypem = "Book";
                    break;
                case "Audiobook":
                    personsAndCompanies = await _mediator.Send(new GetAudiobookAuthorsAndCompaniesListQuery());
                    ViewBag.SelectedTypem = "Audiobook";
                    break;
                case "Film":
                    personsAndCompanies = await _mediator.Send(new GetFilmAuthorsAndCompaniesListQuery());
                    ViewBag.SelectedTypem = "Film";
                    break;
                case "Magazine":
                    personsAndCompanies = await _mediator.Send(new GetMagazineAuthorsAndCompaniesListQuery());
                    ViewBag.SelectedTypem = "Magazine";
                    break;
            }

            var types = new List<SelectListItem>() 
            { 
                new SelectListItem { Text = "Audiobook", Value = "Audiobook" },
                new SelectListItem { Text = "Książka", Value = "Book" },
                new SelectListItem { Text = "Film", Value = "Film" },
                new SelectListItem { Text = "Magazyn", Value = "Magazine" }
            };

            var personsAndCompaniesSelectListVM = new PersonsAndCompaniesSelectListVM
            {
                Persons = personsAndCompanies.Persons.Select(x => new SelectListItem { Text = x.ToString(), Value = Convert.ToString(x.Id) }).ToList(),
                Companies = personsAndCompanies.Companies.Select(x => new SelectListItem { Text = x.ToString(), Value = Convert.ToString(x.Id) }).ToList(),
                Types = types
            };

            return View(personsAndCompaniesSelectListVM);
        }
    }
}
