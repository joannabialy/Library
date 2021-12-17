using Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList;
using Library.Application.ViewModels;
using MediatR;
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

        public async Task<ViewResult> IndexAsync(string type, int companyId, int authorId, int tagId, string search, string previousType)
        {
            var prevoiud = ViewBag.PreviousType;
            var dtos = await _mediator.Send(new GetDigitalEntitiesListQuery());

            var filteredDtos = new List<DigitalEntitiesListVM>();

            if (!string.IsNullOrEmpty(search))
            {
                filteredDtos = dtos.Where(e => e.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            else if (previousType == type)
            {
                filteredDtos = dtos.Where(e => e.Type == type || type == null)
                    .Where(e => e.PersonId == authorId || authorId == 0)
                    .Where(e => e.CompanyId == companyId || companyId == 0)
                    .Where(e => e.Tags.Select(x => x.Id).Contains(tagId) || tagId == 0)
                    .ToList();
            }
            else
            {
                filteredDtos = dtos.Where(e => e.Type == type || type == null).ToList();
            }

            ViewBag.SelectedType = type;

            return View(filteredDtos);
        }

        public ActionResult Details(int id, string type)
        {
            if (!string.IsNullOrEmpty(type))
                return RedirectToAction("Index", type, new { id = id });

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, string type)
        {
            if (!string.IsNullOrEmpty(type))
                return RedirectToAction("Delete", type, new { id = id });

            return RedirectToAction("Index");
        }
    }
}
