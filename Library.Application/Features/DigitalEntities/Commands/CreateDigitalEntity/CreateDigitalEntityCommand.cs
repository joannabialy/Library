using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.DigitalEntities.Commands.CreateDigitalEntity
{
    public class CreateDigitalEntityCommand : IRequest<int>
    {
        public DigitalEntityDto DigitalEntityDto { get; set; }
    }
}
