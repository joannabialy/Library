using AutoMapper;
using Library.Application.Features.DigitalEntities.Commands.CreateDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.DeleteDigitalEntity;
using Library.Application.Features.DigitalEntities.Commands.UpdateDigitalEntity;
using Library.Application.ViewModels;
using Library.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace Library.WebApp.Controllers
{
    public abstract class EntityControllerBase : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public EntityControllerBase(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(DigitalEntityDto dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.DigitalEntityId == 0)
                {
                    var command = new CreateDigitalEntityCommand
                    {
                        DigitalEntityDto = dto
                    };

                    await _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateDigitalEntityCommand
                    {
                        DigitalEntityDto = dto
                    };

                    await _mediator.Send(command);
                }

                return RedirectToAction("Index", "DigitalEntity");
            }
            else
            {
                return View(dto);
            }
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Create()
        {
            return View("Edit", new DigitalEntityDto() { Type = GetEntityType() });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDigitalEntityCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "DigitalEntity");
        }

        protected async Task<DigitalEntityDto> GetDto<T>(IRequest<T> query) where T : DigitalEntity
        {
            var entity = await _mediator.Send(query);

            var dto = _mapper.Map<DigitalEntityDto>(entity);

            dto.Tags = string.Join(",", entity.Tags.Select(x => x.Name));

            return dto;
        }

        protected abstract string GetEntityType();
    }
}
