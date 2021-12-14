using Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class DigitalEntityController : Controller
    {
        private readonly IMediator _mediator;

        public DigitalEntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ViewResult> IndexAsync(string type, int companyId, int authorId, int tagId)
        {
            var dtos = await _mediator.Send(new GetDigitalEntitiesListQuery());

            var filteredDtos = new List<DigitalEntitiesListVM>();

            if (ViewBag.SelectedType == type)
            {
                filteredDtos = dtos.Where(e => e.Type == type || type == null)
                    .Where(e => e.PersonId == authorId || authorId == 0)
                    .Where(e => e.CompanyId == companyId || companyId == 0)
                    .Where(e => e.Tags.Select(x => x.Id).Contains(tagId) || tagId == 0)
                    .ToList();
            }
            else
            {
                filteredDtos = dtos.Where(e => e.Type == type || type == null)
                    .ToList();             
            }

            ViewBag.SelectedType = type;

            return View(filteredDtos);
        }

        public ActionResult Details(int id, string type)
        {
            switch (type)
            {
                case "Audiobook":
                    return RedirectToAction("Index", "Audiobook", new { id = id });
                case "Book":
                    return RedirectToAction("Index", "Book", new { id = id });
                case "Magazine":
                    return RedirectToAction("Index", "Magazine", new { id = id });
                case "Film":
                    return RedirectToAction("Index", "Film", new { id = id });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, string type)
        {
            switch (type)
            {
                case "Audiobook":
                    return RedirectToAction("Delete", "Audiobook", new { id = id });
                case "Book":
                    return RedirectToAction("Delete", "Book", new { id = id });
                case "Magazine":
                    return RedirectToAction("Delete", "Magazine", new { id = id });
                case "Film":
                    return RedirectToAction("Delete", "Film", new { id = id });
            }

            return RedirectToAction("Index");
        }
    }
}
